using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;
using Microsoft.Reporting.WinForms;

namespace Aplicacion.Ventas.Consultas
{
    public partial class FrmConsultaVentaProductosUsuario : Form
    {
        //private BussinesCliente miBussinesCliente;

        private BussinesUsuario miBussinesUsuario;

        private BussinesFacturaVenta miBussinesVenta;

        private BussinesCategoria miBussinesCategoria;

        private BussinesMarca miBussinesMarca;

        private BussinesEmpresa miBussinesEmpresa;

        private List<Producto> Productos;

        private Thread miThread;

        private OptionPane miOption;

        private int IndexFecha;

        private DateTime fecha;

        private DateTime fecha2;

        private int IndexCategoria;

        private string CodCategoria;

        private int IdMarca;

        private int IdUsuario;

        //private string CodProducto;

        public FrmConsultaVentaProductosUsuario()
        {
            InitializeComponent();
            try
            {
                this.dgvProductos.AutoGenerateColumns = false;
                this.Tdatos = new DataTable();
                this.Productos = new List<Producto>();

                //this.miBussinesCliente = new BussinesCliente();
                this.miBussinesUsuario = new BussinesUsuario();
                this.miBussinesVenta = new BussinesFacturaVenta();
                this.miBussinesCategoria = new BussinesCategoria();
                this.miBussinesMarca = new BussinesMarca();
                this.miBussinesEmpresa = new BussinesEmpresa();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmConsultaVentaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbCritFecha.DataSource = new List<string> { "Fecha", "Periodo" };

                this.cbAnios.DataSource = this.miBussinesVenta.Anios();

                this.cbMeses.DataSource = Seleccion.Meses();
                this.cbMeses.SelectedValue = DateTime.Now.Month;
                this.cbMeses_SelectedIndexChanged(this.cbMeses, new EventArgs());
                this.cbDias.SelectedIndex = DateTime.Now.Day - 1;

                this.cbMeses2.DataSource = Seleccion.Meses();
                this.cbMeses2.SelectedValue = DateTime.Now.Month;
                this.cbMeses2_SelectedIndexChanged(this.cbMeses2, new EventArgs());
                this.cbDias2.SelectedIndex = DateTime.Now.Day - 1;

                this.cbUsuario.DataSource = this.miBussinesUsuario.Usuarios();
                this.cbCategoria.DataSource = this.CategoriasItemOpcional();
                this.cbMarcas.DataSource = this.MarcasItemOpcional();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
        
        private void FrmConsultaVentaProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
        }

        private void cbMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbDias.DataSource = Seleccion.Dias(Convert.ToInt32(this.cbMeses.SelectedValue));
        }

        private void cbMeses2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbDias2.DataSource = Seleccion.Dias(Convert.ToInt32(this.cbMeses2.SelectedValue));
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        int IdClasificacion;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.IndexFecha = this.cbCritFecha.SelectedIndex;
            this.IdUsuario = Convert.ToInt32(this.cbUsuario.SelectedValue);
            //this.CodProducto = this.txtProducto.Text;

            this.fecha = new DateTime(
                Convert.ToInt32(this.cbAnios.SelectedValue), Convert.ToInt32(this.cbMeses.SelectedValue), Convert.ToInt32(this.cbDias.SelectedValue));
            this.fecha2 = new DateTime(fecha.Year, Convert.ToInt32(this.cbMeses2.SelectedValue), Convert.ToInt32(this.cbDias2.SelectedValue));

           // this.IdClasificacion = Convert.ToInt32(this.cbUsuario.SelectedValue);
            this.IndexCategoria = this.cbCategoria.SelectedIndex;
            this.CodCategoria = this.cbCategoria.SelectedValue.ToString();
            this.IdMarca = Convert.ToInt32(this.cbMarcas.SelectedValue);

            miOption = new OptionPane();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
            miOption.FrmProgressBar.Closed_ = true;
            miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                "Operacion en progreso");
            this.tsMenu.Enabled = false;
            this.btnBuscar.Enabled = false;
            //this.Enabled = false;
            miThread = new Thread(this.Consultar);
            miThread.Start();
        }
        DataTable Tdatos;
        private void Consultar()
        {
            try
            {
                if (this.IndexFecha == 0)  // Fecha
                {
                    if (this.IndexCategoria == 0)  //  Todas las categorias
                    {
                        if (this.IdMarca == 0)  // Todas las marcas
                        {
                            Tdatos = miBussinesVenta.ConsultaVentasProductosUsuario(fecha, fecha, IdUsuario);

                            //this.Productos = this.miBussinesVenta.VentaProductos(this.fecha);
                        }
                        else  // Marca
                        {
                            Tdatos = miBussinesVenta.ConsultaVentasProductosUsuario(fecha, fecha, IdUsuario, IdMarca);

                            //this.Productos = this.miBussinesVenta.VentaProductos(this.fecha, this.IdMarca);
                        }
                    }
                    else  //  Categoria
                    {
                        if (this.IdMarca == 0)  // Todas las marcas
                        {
                            Tdatos = miBussinesVenta.ConsultaVentasProductosUsuario(fecha, fecha, IdUsuario, CodCategoria);

                            //this.Productos = this.miBussinesVenta.VentaProductos(this.fecha, this.CodCategoria);
                        }
                        else  // Marca
                        {
                            Tdatos = miBussinesVenta.ConsultaVentasProductosUsuario(fecha, fecha, IdUsuario, CodCategoria, IdMarca);
                            //this.Productos = this.miBussinesVenta.VentaProductos(this.fecha, this.CodCategoria, this.IdMarca);
                        }
                    }
                }
                else   //  Periodo
                {
                    if (this.IndexCategoria == 0)  //  Todas las categorias
                    {
                        if (this.IdMarca == 0)  // Todas las marcas
                        {
                            Tdatos = miBussinesVenta.ConsultaVentasProductosUsuario(fecha, fecha2, IdUsuario);
                            //this.Productos = this.miBussinesVenta.VentaProductos(this.fecha, this.fecha2);
                        }
                        else  // Marca
                        {
                            Tdatos = miBussinesVenta.ConsultaVentasProductosUsuario(fecha, fecha2, IdUsuario, IdMarca);
                            //this.Productos = this.miBussinesVenta.VentaProductos(this.fecha, this.fecha2, this.IdMarca);
                        }
                    }
                    else  //  Categoria
                    {
                        if (this.IdMarca == 0)  // Todas las marcas
                        {
                            Tdatos = miBussinesVenta.ConsultaVentasProductosUsuario(fecha, fecha2, IdUsuario, CodCategoria);
                            //this.Productos = this.miBussinesVenta.VentaProductos(this.fecha, this.fecha2, this.CodCategoria);
                        }
                        else  // Marca
                        {
                            Tdatos = miBussinesVenta.ConsultaVentasProductosUsuario(fecha, fecha2, IdUsuario, CodCategoria, IdMarca);
                            //this.Productos = this.miBussinesVenta.VentaProductos(this.fecha, this.fecha2, this.CodCategoria, this.IdMarca);
                        }
                    }
                }

                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
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
            //this.txtProducto.Text = "";
            if(this.Tdatos.Rows.Count != 0) //if (this.Productos.Count != 0)
            {
                try
                {
                    this.dgvProductos.DataSource = this.Tdatos;
                    this.txtTotalCantidad.Text = UseObject.InsertSeparatorMil(this.Tdatos.AsEnumerable().Sum(s => s.Field<double>("cantidad")).ToString());
                    this.txtTotal.Text = UseObject.InsertSeparatorMil(this.Tdatos.AsEnumerable().Sum(s => s.Field<double>("total")).ToString());

                    //this.dgvProductos.DataSource = this.Productos;
                    //this.txtTotal.Text = UseObject.InsertSeparatorMil(this.Productos.Sum(s => s.ValorVentaProducto).ToString());

                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                    miOption.FrmProgressBar.Closed_ = false;
                    miOption.FrmProgressBar.Close();
                    this.tsMenu.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    //this.Enabled = true;
                }
                catch (Exception ex)
                {
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                    miOption.FrmProgressBar.Closed_ = false;
                    miOption.FrmProgressBar.Close();
                    this.tsMenu.Enabled = true;
                    this.btnBuscar.Enabled = true;
                    //this.Enabled = true;
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                this.dgvProductos.DataSource = null;
                this.txtTotal.Text = "0";
                //LimpiarResumen();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.tsMenu.Enabled = true;
                this.btnBuscar.Enabled = true;
                //this.Enabled = true;
            }
        }

        private DataTable CategoriasItemOpcional()
        {
            DataTable categorias = this.miBussinesCategoria.ListadoCategoria();
            DataRow cRow = categorias.NewRow();
            cRow["codigocategoria"] = 0;
            cRow["nombrecategoria"] = "[TODAS LAS CATEGORIAS]";
            categorias.Rows.InsertAt(cRow, 0);
            return categorias;
        }

        private ArrayList MarcasItemOpcional()
        {
            ArrayList marcas = this.miBussinesMarca.ListarMarcas();
            marcas.Insert(0, new Marca { IdMarca = 0, NombreMarca = "[TODAS LAS MARCAS]" });
            return marcas;
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Tdatos.Rows.Count > 0)
                {
                    var dsEmpresa = this.miBussinesEmpresa.PrintEmpresa();

                    var frmPrint = new Ventas.Factura.FrmPrintFactura();
                    frmPrint.RptvFactura.ShowExportButton = true;

                    frmPrint.RptvFactura.LocalReport.DataSources.Clear();
                    frmPrint.RptvFactura.LocalReport.Dispose();
                    frmPrint.RptvFactura.Reset();

                    frmPrint.RptvFactura.LocalReport.DataSources.Add(
                        new ReportDataSource("DsEmpresa", dsEmpresa.Tables["Empresa"]));

                    var tProductos = new DataTable();
                    tProductos.Columns.Add("CodigoInternoProducto");
                    tProductos.Columns.Add("NombreProducto");
                    tProductos.Columns.Add("Cantidad", typeof(double));
                    tProductos.Columns.Add("ValorVentaProducto", typeof(double));
                    tProductos.Columns.Add("ValorCosto", typeof(double));

                    foreach (DataRow p in this.Tdatos.Rows)
                    {
                        var pRow = tProductos.NewRow();
                        pRow["CodigoInternoProducto"] = p["codigo"];
                        pRow["NombreProducto"] = p["producto"];
                        pRow["Cantidad"] = p["cantidad"];
                        pRow["ValorCosto"] = p["promedio"];
                        pRow["ValorVentaProducto"] = p["total"];
                        tProductos.Rows.Add(pRow);
                    }

                    /*foreach (var p in this.Productos)
                    {
                        var pRow = tProductos.NewRow();
                        pRow["CodigoInternoProducto"] = p.CodigoInternoProducto;
                        pRow["NombreProducto"] = p.NombreProducto;
                        pRow["Cantidad"] = p.Cantidad;
                        pRow["ValorCosto"] = p.ValorCosto;
                        pRow["ValorVentaProducto"] = p.ValorVentaProducto;
                        tProductos.Rows.Add(pRow);
                    }*/
                   /* var tProductos = this.Productos.ToDataTable();
                    /*tProductos.TableName = "Producto";*/
                    frmPrint.RptvFactura.LocalReport.DataSources.Add(new ReportDataSource("DsDtoProducto", tProductos));

                    //frmPrint.RptvFactura.LocalReport.ReportPath = @"C:\reports\ConsultaVentaProductosClienteClasifi.rdlc";
                    frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ConsultaVentaProductosClienteClasifi.rdlc";

                    var pFecha = new ReportParameter();
                    pFecha.Name = "Fecha";
                    if (this.IndexFecha == 0)
                    {
                        pFecha.Values.Add("Fecha: " + this.fecha.ToShortDateString());
                    }
                    else
                    {
                        pFecha.Values.Add("Periodo: " + this.fecha.ToShortDateString() + " a " + this.fecha2.ToShortDateString());
                    }
                    frmPrint.RptvFactura.LocalReport.SetParameters(pFecha);

                    var pClasificacion = new ReportParameter();
                    pClasificacion.Name = "Clasificacion";
                    //if (this.IdClasificacion != 0)
                    //{
                        pClasificacion.Values.Add("Usuario: " + this.cbUsuario.Text);
                    //}
                    frmPrint.RptvFactura.LocalReport.SetParameters(pClasificacion);

                    var pCategoria = new ReportParameter();
                    pCategoria.Name = "Categoria";
                    //if (this.IndexCategoria != 0)
                   // {
                        pCategoria.Values.Add("Categoria: " + this.cbCategoria.Text);
                   // }
                    frmPrint.RptvFactura.LocalReport.SetParameters(pCategoria);

                    var pMarca = new ReportParameter();
                    pMarca.Name = "Marca";
                    //if (this.IdMarca != 0)
                   // {
                        pMarca.Values.Add("Marca: " + this.cbMarcas.Text);
                   // }
                    frmPrint.RptvFactura.LocalReport.SetParameters(pMarca);

                    frmPrint.RptvFactura.RefreshReport();
                    frmPrint.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar una consulta");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        

    }
}