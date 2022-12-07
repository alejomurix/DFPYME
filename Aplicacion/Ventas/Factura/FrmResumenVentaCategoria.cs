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
using System.Threading;
using DTO.Clases;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmResumenVentaCategoria : Form
    {
        private BussinesFacturaVenta miBussinesFactura;

        private BussinesCategoria miBussinesCategoria;
        
        private BussinesUsuario miBussinesUsuario;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa el Stream de la Imagen de Ver Utilidad.
        /// </summary>
        private System.IO.Stream ImgUtilidadStream;

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de color gris de Ver Utilidad
        /// </summary>
        private const string ImagenUtilidad = "Aplicacion.Recursos.Iconos.table_money_gris.png";

        private bool VerUtilidad;

        private bool NoVerUtilidad;

        private bool Transfer { set; get; }

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        private Thread miThread;

        private OptionPane miOption;

        private string NitActual { set; get; }

        private DateTime FechaActual { set; get; }

        private DateTime FechaActual2 { set; get; }

        private DataTable TResumen { set; get; }

        private Categoria miCategoria;

        private ErrorProvider miError;

        private List<Categoria> ListCategoria;

        private List<Categoria> List_Categoria;

        private Categoria CategoriaData , CategoriaData2;

        

        public FrmResumenVentaCategoria()
        {
            InitializeComponent();
            this.miCategoria = new Categoria();
            this.miError = new ErrorProvider();

            this.miBussinesCategoria = new BussinesCategoria();

            this.Transfer = false;
            this.VerUtilidad = true;
            this.NoVerUtilidad = true;
            this.miBussinesFactura = new BussinesFacturaVenta();
            this.miBussinesUsuario = new BussinesUsuario();
            this.TResumen = new DataTable();

            this.ListCategoria = new List<Categoria>();
            this.List_Categoria = new List<Categoria>();
        }

        private void FrmResumenVenta_Load(object sender, EventArgs e)
        {
            this.assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            this.dgvTotales.AutoGenerateColumns = false;
            CargarDatos();
            //this.miBussinesFactura.VistaFaltante();
        }

        private void FrmResumenVenta_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void btnVerUtilidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VerUtilidad)
                {
                        string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (!rta.Equals("false"))
                        {
                            if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                            {
                                this.btnVerUtilidad.Image = new Bitmap(ImgUtilidadStream);
                                this.btnVerUtilidad.Text = "No Ver Utilidad";
                                this.NoVerUtilidad = true;
                                this.VerUtilidad = false;

                                this.txtCosto.Visible = true;
                                this.txtVenta.Visible = true;
                                this.txtUtilidad.Visible = true;

                                this.txtCostoView.Visible = false;
                                this.txtVentaView.Visible = false;
                                this.txtUtilidadView.Visible = false;
                            }
                            else
                            {
                                OptionPane.MessageError("La contraseña es incorrecta.");
                            }
                        }
                }
                else
                {
                    if (this.NoVerUtilidad)
                    {
                        this.btnVerUtilidad.Image = ((Image)(miResources.GetObject("btnVerUtilidad.Image")));
                        this.btnVerUtilidad.Text = "Ver Utilidad";
                        this.NoVerUtilidad = false;
                        this.VerUtilidad = true;
                        this.txtCosto.Visible = false;
                        this.txtVenta.Visible = false;
                        this.txtUtilidad.Visible = false;

                        this.txtCostoView.Visible = true;
                        this.txtVentaView.Visible = true;
                        this.txtUtilidadView.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (!String.IsNullOrEmpty(this.txtCodCategoria.Text))
                    {
                        if (CodigoOString(this.txtCodCategoria.Text))
                        {
                            var arrCategoria = miBussinesCategoria.consultaCategoriaCodigo(this.txtCodCategoria.Text);
                            if (arrCategoria.Count > 0)
                            {
                                this.miCategoria = (Categoria)arrCategoria[0];
                                var categoria = (DTO.Clases.Categoria)arrCategoria[0];
                                this.txtCategoria.Text = this.miCategoria.NombreCategoria;
                                this.dtpFecha1.Focus();
                            }
                        }
                        else
                        {
                            var frmCategoria = new Inventario.Categoria.FrmCategoriaNuevo();
                            frmCategoria.Extension = true;
                            frmCategoria.PressBoton = false;
                            frmCategoria.txtConsulta.Text = this.txtCodCategoria.Text;
                            DialogResult rta = frmCategoria.ShowDialog();
                        }
                    }
                    else
                    {
                        this.btnBuscarCategoria_Click(this.btnBuscarCategoria, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            var frmCategoria = new Inventario.Categoria.FrmCategoriaNuevo();
            frmCategoria.Extension = true;
            frmCategoria.ShowDialog();
            if (!String.IsNullOrEmpty(this.miCategoria.CodigoCategoria))
            {
                this.dtpFecha1.Focus();
            }
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
            {
                this.dtpFecha2.Enabled = false;
            }
            else
            {
                this.dtpFecha2.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cFecha = Convert.ToInt32(cbFecha.SelectedValue);
            if (!String.IsNullOrEmpty(this.miCategoria.CodigoCategoria))
            {
                this.miError.SetError(this.txtCategoria, null);
                if (cFecha.Equals(1)) // fecha
                {
                    this.Iteracion = 1;
                }
                else  // periodo
                {
                    this.Iteracion = 2;
                }
                this.FechaActual = this.dtpFecha1.Value;
                this.FechaActual2 = this.dtpFecha2.Value;

                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Consultar);
                this.miThread.Start();
            }
            else
            {
                this.miError.SetError(this.txtCategoria, "Debe cargar una categoría.");
            }

                //LimpiarResumen();
                ///OptionPane.MessageInformation("No se encontraron registros de la consulta.");
            
        }

        private void CargarDatos()
        {
            var lst = new List<Inventario.Producto.Criterio>();

            lst = new List<Inventario.Producto.Criterio>();
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
            cbFecha.DataSource = lst;
            try
            {
                this.ImgUtilidadStream = assembly.GetManifestResourceStream(ImagenUtilidad);

                // Datos para consulta de ventas por categoria
                if (AppConfiguracion.ValorSeccion("c_categoriaPredeterminada_1") != "")
                {
                    this.ListCategoria.Add(new Categoria
                    {
                        CodigoCategoria = AppConfiguracion.ValorSeccion("c_categoriaPredeterminada_1"),
                        NombreCategoria = AppConfiguracion.ValorSeccion("n_categoriaPredeterminada_1")
                    });
                    if (AppConfiguracion.ValorSeccion("c_categoriaPredeterminada_2") != "")
                    {
                        this.ListCategoria.Add(new Categoria
                        {
                            CodigoCategoria = AppConfiguracion.ValorSeccion("c_categoriaPredeterminada_2"),
                            NombreCategoria = AppConfiguracion.ValorSeccion("n_categoriaPredeterminada_2")
                        });
                    }
                    this.ListCategoria.Add(new Categoria
                    {
                        NombreCategoria = "DEMAS"
                    });
                    this.dgvTotales.DataSource = this.ListCategoria;
                }

                this.CategoriaData = new Categoria();
                this.txtCodCategoriaRemision.Text = this.CategoriaData.CodigoCategoria = AppConfiguracion.ValorSeccion("cod_categoria_seleccionada");
                this.txtNameCategoriaRemision.Text = this.CategoriaData.NombreCategoria = AppConfiguracion.ValorSeccion("name_categoria_seleccionada");

                CategoriaData2 = new Categoria();
                this.txtCodCategoriaVerdura.Text = this.CategoriaData2.CodigoCategoria = AppConfiguracion.ValorSeccion("cod_categoria_seleccionada_2");
                this.txtNameCategoriaVerdura.Text = this.CategoriaData2.NombreCategoria = AppConfiguracion.ValorSeccion("name_categoria_seleccionada_2");
                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                this.miCategoria = (Categoria)args.MiMarca;
                this.txtCodCategoria.Text = this.miCategoria.CodigoCategoria;
                this.txtCategoria.Text = this.miCategoria.NombreCategoria;
                this.dtpFecha1.Focus();
            }
            catch { }

            try
            {
                this.ListCategoria = (List<Categoria>)args.MiMarca;
                this.dgvTotales.DataSource = this.ListCategoria;
            }
            catch { }
        }

        private bool CodigoOString(string codigo)
        {
            var num = true;
            try
            {
                Convert.ToInt64(codigo);
                num = true;
            }
            catch (FormatException)
            {
                num = false;
            }
            return num;
        }

        private void Consultar()
        {
            try
            {
                switch (this.Iteracion)
                {
                    case 1:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCategoria(this.miCategoria.CodigoCategoria, this.FechaActual);
                            break;
                        }
                    case 2:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCategoria(this.miCategoria.CodigoCategoria, this.FechaActual, this.FechaActual2);
                            break;
                        }
                }
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
        }

        private void Finalizar()
        {
            if (this.TResumen.Rows.Count != 0)
            {
                try
                {
                    this.txtBase.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Base"))).ToString());
                    this.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Iva"))).ToString());
                    this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());

                    // Resumen Tributario
                    this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                    this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Iva"))).ToString());
                    this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                    // Resumen de Utilidad
                    this.txtCosto.Text = UseObject.InsertSeparatorMil(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<Int64>("TotalC")).ToString());
                    this.txtVenta.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());
                    this.txtUtilidad.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        UseObject.RemoveSeparatorMil(this.txtVenta.Text) - UseObject.RemoveSeparatorMil(this.txtCosto.Text)).ToString());

                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                    miOption.FrmProgressBar.Closed_ = false;
                    miOption.FrmProgressBar.Close();
                    this.Enabled = true;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                    miOption.FrmProgressBar.Closed_ = false;
                    miOption.FrmProgressBar.Close();
                    this.Enabled = true;
                }
            }
            else
            {
                LimpiarResumen();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
            }
        }

        private void LimpiarResumen()
        {
            this.txtBase.Text = "0";
            this.txtIva.Text = "0";
            this.txtTotal.Text = "0";

            this.txtIvaCompra.Text = "0";
            this.txtIvaVenta.Text = "0";
            this.txtDiferencia.Text = "0";

            this.txtCosto.Text = "0";
            this.txtVenta.Text = "0";
            this.txtUtilidad.Text = "0";
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            var frmCategorias = new FrmCategorias();
            frmCategorias.ShowDialog();
        }
         
        private void btnBuscarTotalesCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvTotales.Rows.Count > 0)
                {
                    AppConfiguracion.SaveConfiguration("c_categoriaPredeterminada_1", this.ListCategoria[0].CodigoCategoria);
                    AppConfiguracion.SaveConfiguration("n_categoriaPredeterminada_1", this.ListCategoria[0].NombreCategoria);

                    AppConfiguracion.SaveConfiguration("c_categoriaPredeterminada_2", this.ListCategoria[1].CodigoCategoria);
                    AppConfiguracion.SaveConfiguration("n_categoriaPredeterminada_2", this.ListCategoria[1].NombreCategoria);

                    if (Convert.ToInt32(cbFecha.SelectedValue).Equals(1)) // fecha
                    {
                        this.Iteracion = 1;
                    }
                    else  // periodo
                    {
                        this.Iteracion = 2;
                    }
                    this.FechaActual = this.dtpFecha1.Value;
                    this.FechaActual2 = this.dtpFecha2.Value;

                    this.miOption = new OptionPane();
                    this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                    this.miOption.FrmProgressBar.Closed_ = true;
                    this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                        "Operacion en progreso");
                    this.Enabled = false;
                    this.miThread = new Thread(ConsultarCategorias);
                    this.miThread.Start();
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar las categorias a consultar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvTotales.Rows.Count > 0)
                {
                    var miBussinesEmpresa = new BussinesEmpresa();
                    DataRow empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                    Ticket ticket = new Ticket();
                    ticket.UseItem = false;

                    ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                    ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                    ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                    ticket.AddHeaderLine("Régimen: " + empresaRow["Regimen"].ToString());
                    ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("INFORME DE VENTAS POR CATEGRORIAS  ");
                    if (this.Iteracion.Equals(1))
                    {
                        ticket.AddHeaderLine("Fecha : " + this.FechaActual.ToShortDateString());
                    }
                    else
                    {
                        ticket.AddHeaderLine("Periodo : " + this.FechaActual.ToShortDateString() + " al " + this.FechaActual2.ToShortDateString());
                    }
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");
                    int maxCharacters_18 = 18;
                    int maxCharacters_15 = 15;
                    string valor = "";
                    List<string> datos = new List<string>();
                    foreach (var categoria in this.ListCategoria)
                    {
                        if (categoria.CodigoCategoria == "")
                        {
                            categoria.CodigoCategoria = "     ";
                        }
                        valor = UseObject.InsertSeparatorMil(categoria.Valor.ToString());
                        datos = UseObject.StringBuilderDataIzquierda(categoria.CodigoCategoria + "  " + categoria.NombreCategoria, maxCharacters_18);
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
                            ticket.AddHeaderLine("");
                        }
                    }
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("");

                    ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(
                        UseObject.InsertSeparatorMil(this.ListCategoria.Sum(s => s.Valor).ToString())));
                    ticket.AddHeaderLine("");
                    ticket.AddHeaderLine("-----------------------------------");
                    ticket.AddHeaderLine("Software: DFPyme");
                    ticket.PrintTicket("");

                    /*foreach (var categoria in this.ListCategoria)
                    {
                        ticket.AddItem(categoria.CodigoCategoria,
                                       categoria.NombreCategoria,
                                       UseObject.InsertSeparatorMil(categoria.Valor.ToString()));
                        ticket.AddItem("", "", "");
                    }
                    ticket.AddTotal("TOTAL:   ", UseObject.InsertSeparatorMil(this.ListCategoria.Sum(s => s.Valor).ToString()));
                    ticket.AddFooterLine("-----------------------------------");
                    ticket.AddFooterLine("Software: DFPyme");
                    ticket.PrintTicket("IMPREPOS");*/
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar la consulta de categorias.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultarCategorias()
        {
            try
            {
                if (this.Iteracion == 1)
                {
                    this.List_Categoria = 
                        this.miBussinesCategoria.ResumenVentasTodasCategorias(this.ListCategoria, this.FechaActual, this.FechaActual2, true);
                    this.CategoriaData = this.miBussinesCategoria.CategoriaData(this.CategoriaData, this.FechaActual);
                    CategoriaData2 = miBussinesCategoria.CategoriaData(CategoriaData2, FechaActual);
                }
                else
                {
                    this.List_Categoria =
                        this.miBussinesCategoria.ResumenVentasTodasCategorias(this.ListCategoria, this.FechaActual, this.FechaActual2, false);
                    this.CategoriaData = this.miBussinesCategoria.CategoriaData(this.CategoriaData, this.FechaActual, FechaActual2);
                    CategoriaData2 = miBussinesCategoria.CategoriaData(CategoriaData2, FechaActual, FechaActual2);
                }

                if (this.InvokeRequired)
                    this.Invoke(new Action(FinalizarCategorias));
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinalizarCategorias));
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FinalizarCategorias()
        {
            try
            {
                foreach (var categoria in this.ListCategoria)
                {
                    categoria.Valor = this.List_Categoria.Where(c => c.CodigoCategoria == categoria.CodigoCategoria).Sum(s => s.Valor);
                }
                this.dgvTotales.DataSource = this.ListCategoria;
                this.txtTotalVentasCategorias.Text = UseObject.InsertSeparatorMil(this.ListCategoria.Sum(s => s.Valor).ToString());

                this.txtValorCategoriaRemision.Text = UseObject.InsertSeparatorMil(this.CategoriaData.Valor.ToString());

                this.txtTotalCategoriaVentaRemision.Text = UseObject.InsertSeparatorMil((this.CategoriaData.Valor +
                    this.List_Categoria.Where(c => c.CodigoCategoria.Equals(this.CategoriaData.CodigoCategoria)).Sum(s => s.Valor)).ToString());


                txtValorCatVerduraRemision.Text = UseObject.InsertSeparatorMil(this.CategoriaData2.Valor.ToString());

                txtTotalCatVerduraVentaRemision.Text = UseObject.InsertSeparatorMil((this.CategoriaData2.Valor +
                    this.List_Categoria.Where(c => c.CodigoCategoria.Equals(this.CategoriaData2.CodigoCategoria)).Sum(s => s.Valor)).ToString());
                    
                /*if (this.List_Categoria.Count > 0)
                {
                    this.dgvTotales.DataSource = this.List_Categoria;
                }
                else
                {
                    this.dgvTotales.DataSource = this.ListCategoria;
                }*/

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }

    }
}