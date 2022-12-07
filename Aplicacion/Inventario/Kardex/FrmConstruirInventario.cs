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
using System.Threading;

namespace Aplicacion.Inventario.Kardex
{
    public partial class FrmConstruirInventario : Form
    {
        #region Atributos

        private BussinesKardex miBussinesKardex;


        private BussinesInventario miBussinesInventario;

        private BussinesProducto miBussinesProducto;

        private ToolTip miToolTip;

        private bool ExtendForms { set; get; }

        public bool ExtendForms_ { set; get; }

        public bool ExtendVenta = false;

        public bool IsVenta = true;

        public bool IsCompra = false;

        private DataTable Tabla { set; get; }

        private Thread miThread;

        private OptionPane miOption;

        private int Iteracion;

        private int RowInventario;

        private int RowMaxInventario;

        private long Pages;

        private long TotalRows;

        private int CurrentPage;

        private string CodigoActual;

        private string NombreActual;

        private string CategoriaActual;

        #endregion

        public bool Consulta { set; get; }

        public FrmConstruirInventario()
        {
            this.miBussinesKardex = new BussinesKardex();

            miBussinesInventario = new BussinesInventario();
            miBussinesProducto = new BussinesProducto();
            miToolTip = new ToolTip();
            RowMaxInventario = 15;
            InitializeComponent();
            this.Consulta = true;
            this.ExtendForms_ = false;
        }

        private void FrmConsultaInventario_Load(object sender, EventArgs e)
        {
           CargarUtilidades();
            dgvInventario.AutoGenerateColumns = false;
            CompletaEventos.CompletaEditProveedor += 
                new CompletaEventos.CompletaAccionEditProveedor(CompletaEventos_Completo);
            CompletaEventos.Completam += 
                new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            /*assembly = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                ImgCostoStream = assembly.GetManifestResourceStream(ImagenLote);
                ImgPdistriStream = assembly.GetManifestResourceStream(ImagenPdistri);
            }
            catch
            {
                OptionPane.MessageError("Ocurrió un error al cargar los recursos.");
            }
            if (ExtendVenta)
            {
                //  Nuevo codigo 21-05-2019
                Categoria.Visible = false;
                dgvInventario.Columns["Producto"].Width += Categoria.Width;


                tsBtnSeleccionar.Visible = true;
                cbCriterio1.SelectedValue = 2;
                if (Consulta)
                {
                    btnConsultar_Click(this.btnConsultar, new EventArgs());
                }
            }
            else
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("verCosto")))
                {
                    
                }
                else
                {
                    tsVerCosto.Enabled = true;
                    Valor.Visible = false;
                    dgvInventario.Columns["Producto"].Width = Producto.Width + Valor.Width;
                }
            }
            tsVerPrecioDistri.Image = new Bitmap(ImgPdistriStream);
            tsVerPrecioDistri.Text = "No ver P. Distribuidor(3)";
            dgvInventario.Columns["PDistribuidor"].Visible = true;*/
        }

        private void FrmConsultaInventario_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F5:
                    {
                        this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                        break;
                    }
                case Keys.F7:
                    {
                        //this.dgvInventario.Focus();
                        this.tsBtnSelecionaGrid_Click(this.tsBtnSelecionaGrid, new EventArgs());
                        break;
                    }
                case Keys.F9:
                    {
                        this.tsBtnNuevoArticulo_Click(this.tsBtnNuevoArticulo, new EventArgs());
                        break;
                    }
                case Keys.F10:
                    {
                        this.tsBtnImprimirConsulta_Click(this.tsBtnImprimir, new EventArgs());
                        break;
                    }
                case Keys.F11:
                    {
                        this.tsBtnImprimir_Click(this.tsBtnImprimirConsulta, new EventArgs());
                        break;
                    }
                case Keys.F12:
                    {
                        this.tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
                        break;
                    }
                case Keys.Add: // " + "
                    {
                        if (this.dgvInventario.Focused)
                        {
                           // this.btnSiguiente_Click(this.btnSiguiente, new EventArgs());
                        }
                        break;
                    }
                case Keys.Subtract:  // " - "
                    {
                        if (this.dgvInventario.Focused)
                        {
                           // this.btnAnterior_Click(this.btnAnterior, new EventArgs());
                        }
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }


            /*var criterio = (int)cbCriterio.SelectedValue;
            if (e.KeyData.Equals(Keys.F1))
            {
                dgvInventario.Focus();
            }
            else
            {
                if (e.KeyData.Equals(Keys.F2))
                {
                    this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                }
                else
                {
                    if (e.KeyData == Keys.F4)
                    {
                        txtCodigoNombre.Focus();
                        cbCriterio1.SelectedIndex = 1;
                        //btnBuscar_Click(this.btnBuscar, new EventArgs());
                    }
                    else
                    {
                        if (e.KeyData.Equals(Keys.F5))
                        {
                            cbCriterio1.Focus();
                        }
                        else
                        {
                            if (e.KeyData.Equals(Keys.F12))
                            {
                                if (ExtendVenta)
                                {
                                    this.tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
                                }
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
            }*/
        }

        private void FrmConsultaInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExtendVenta)
            {
                if (IsCompra)
                {
                    CompletaEventos.CapturaEvenTransInvFactProvee(false);
                }
                else
                {
                    if (IsVenta)
                    {
                        CompletaEventos.CapturaEvento(false);
                    }
                    else
                    {
                        CompletaEventos.CapturaEventoRemision(false);
                    }
                }
            }
        }

        private void tsBtnSelecionaGrid_Click(object sender, EventArgs e)
        {
            //dgvInventario.Focus();
            this.txtCodigoNombre.Focus();
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            this.Iteracion = 1;
            this.CurrentPage = 1;

            this.dgvInventario.AutoGenerateColumns = false;

            /*miOption = new OptionPane();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
            miOption.FrmProgressBar.Closed_ = true;
            miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                "Operacion en progreso");*/
            miThread = new Thread(Consultar);
            miThread.Start();

            /*RowInventario = 0;
            Iteracion = 1;
            CurrentPage = 1;
            try
            {
                dgvInventario.DataSource =
                    miBussinesInventario.ConsultaInventario(RowInventario, RowMaxInventario);
                TotalRows = miBussinesInventario.GetRowsConsultaInventario();
                if (dgvInventario.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encuentran registros en el Inventario.");
                }
                else
                {
                    ColorearGrid();
                    this.dgvInventario.Focus();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();*/
        }

        private void tsBtnCriterio_Click(object sender, EventArgs e)
        {
            txtCodigoNombre.Focus();
           // cbCriterio1.SelectedIndex = 1;
        }

        private void tsBtnSeleccionarCriterio_Click(object sender, EventArgs e)
        {
           // cbCriterio1.Focus();
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            this.dgvInventario_KeyPress(this.dgvInventario, new KeyPressEventArgs((char)Keys.D1));
            /*if (!dgvInventario.RowCount.Equals(0))
            {
                var producto = new DTO.Clases.Producto();
                producto.CodigoInternoProducto = dgvInventario.CurrentRow.Cells["Codigo"].Value.ToString();
                if (ExtendVenta)
                {
                    if (IsCompra)
                    {
                        CompletaEventos.CapturaEvenTransInvFactProvee(producto);
                    }
                    else
                    {
                        if (IsVenta)
                        {
                            CompletaEventos.CapEventoTransferProductFact(producto);
                        }
                        else
                        {
                            CompletaEventos.CapturaEventom(producto);
                        }
                    }
                    //CompletaEventos.CapturaEventom(producto);
                    this.Close();
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para cargar.");
            }*/
        }

        private void tsBtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            var formProducto = new Inventario.Producto.FrmIngresarProducto();
            //formProducto.Extend = true;
            formProducto.MdiParent = this.MdiParent;
            formProducto.Extencion = true;
            //formProducto.tabControlProducto.SelectedIndex = 1;
            formProducto.Show();
        }

        private void tsBtnImprimirConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvInventario.RowCount != 0)
                {
                    var tProductos = new DataTable();
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                //tProductos = this.miBussinesInventario.ConsultaInventario();
                                tProductos = this.miBussinesInventario.ConsultaInventario_();
                                break;
                            }
                        case 2:
                            {
                                tProductos = this.miBussinesInventario.ConsultaInventario_(this.CodigoActual);
                                break;
                            }
                        case 3:
                            {
                                tProductos = this.miBussinesInventario.ConsultaInventarioNombre_(this.NombreActual);
                                break;
                            }
                        case 4:
                            {
                                tProductos = this.miBussinesInventario.ConsultaInventarioCategoria_(this.CategoriaActual);
                                break;
                            }
                    }
                    var frmPrintInforme = new Inventario.Cruce.FrmInformeInventario();
                    frmPrintInforme.Tabla = tProductos; //
                    //frmPrintInforme.Tabla = miBussinesInventario.InformeInventario();
                    frmPrintInforme.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeInventario.rdlc";
                    //frmPrintInforme.ReportPath = @"C:\reports\InformeInventario.rdlc";

                   /* frmPrintInforme.ReportPath =
@"C:\Users\alejoQ2009\Documents\Visual Studio 2010\Projects\Edicion\DFPYME\Aplicacion\Informes\InformeInventario.rdlc";
                  */
                    frmPrintInforme.Fecha = DateTime.Now;
                    frmPrintInforme.ShowDialog();
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar una consulta.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            string pError = "";
            try
            {
                if (this.dgvInventario.RowCount != 0)
                {
                    var tProductos = new DataTable();
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                tProductos = this.miBussinesInventario.ConsultaInventario();
                                break;
                            }
                        case 2:
                            {
                                tProductos = this.miBussinesInventario.ConsultaInventario(this.CodigoActual);
                                break;
                            }
                        case 3:
                            {
                                tProductos = this.miBussinesInventario.ConsultaInventarioNombre(this.NombreActual);
                                break;
                            }
                        case 4:
                            {
                                tProductos = this.miBussinesInventario.ConsultaInventarioCategoria(this.CategoriaActual);
                                break;
                            }
                    }
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printInventario")))
                    {
                        DialogResult rta = MessageBox.Show("¿Desea que se imprima las cantidades?", "Inventario",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        var miBussinesEmpresa = new BussinesEmpresa();

                        var empresaRow = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();

                        Ticket ticket = new Ticket();
                        ticket.UseItem = false;
                        ticket.AddHeaderLine(empresaRow["Nombre"].ToString().ToUpper());
                        ticket.AddHeaderLine(empresaRow["Juridico"].ToString());
                        ticket.AddHeaderLine("NIT " + UseObject.InsertSeparatorMilMasDigito(empresaRow["Nit"].ToString()));
                        ticket.AddHeaderLine(empresaRow["Direccion"].ToString());
                        ticket.AddHeaderLine("Tels. " + empresaRow["Telefono"].ToString());
                        ticket.AddHeaderLine("REGIMEN " + empresaRow["Regimen"].ToString());

                        ticket.AddHeaderLine("===================================");
                        ticket.AddHeaderLine("LISTADO DE PRODUCTOS");
                        ticket.AddHeaderLine("===================================");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("COD.  DESCRIP.        CANT.   VENTA");
                        ticket.AddHeaderLine("___________________________________");//35 CARACTERES
                        ticket.AddHeaderLine("");
                        
                        foreach (DataRow row in tProductos.AsEnumerable().OrderBy(o => o.Field<string>("nombre")))
                        {
                          //  pError = row["codigo"].ToString();
                         /*   if (pError == "274")
                            {
                                var j = pError;
                            }*/
                            string product = row["nombre"].ToString();
                            if (product.Length > 29)
                            {
                                product = product.Substring(0, 29);
                            }
                            //ticket.AddHeaderLine(row["codigo"].ToString() + " " + product);
                            //ticket.AddHeaderLine(row["codigo"].ToString() + " " + UseObject.AjusteDeCaracteres(product, 29));
                            ticket.AddHeaderLine(UseObject.AjusteDeCaracteresDerecha(row["codigo"].ToString(), 5) + " " + product);
                            if (rta.Equals(DialogResult.Yes))
                            {
                                ticket.AddHeaderLine("                     " + UseObject.AjusteDeCaracteres(row["cantidad"].ToString(), 5) + " " +
                                    UseObject.AjusteDeCaracteres(UseObject.InsertSeparatorMil(row["venta"].ToString()), 8));
                            }
                            else
                            {
                                ticket.AddHeaderLine("                      _____" + " " +
                                    UseObject.AjusteDeCaracteres(UseObject.InsertSeparatorMil(row["venta"].ToString()), 7));
                            }
                        }
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("===================================");
                        ticket.AddHeaderLine("");
                        ticket.AddHeaderLine("Software: Digital Fact Pyme");
                        //ticket.AddHeaderLine("solucionestecnologicasayc@gmail.com");
                        ticket.AddHeaderLine("");
                        ticket.PrintTicket("IMPREPOS");
                    }
                    else
                    {
                        var frmPrintInforme = new Inventario.Cruce.FrmInformeInventario();
                        frmPrintInforme.Tabla = tProductos; //
                        //frmPrintInforme.Tabla = miBussinesInventario.InformeInventario();
                        frmPrintInforme.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeInventarioVenta.rdlc";
                        //frmPrintInforme.ReportPath = @"C:\reports\InformeInventarioVenta.rdlc";
                        frmPrintInforme.Fecha = DateTime.Now;
                        frmPrintInforme.ShowDialog();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar una consulta.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*if (Convert.ToInt32(cbCriterio.SelectedValue) == 1)
            {
                cbCriterio1.Enabled = true;
                miToolTip.SetToolTip(btnBuscar, "Buscar Producto [F4]");
            }
            else
            {
                cbCriterio1.SelectedValue = 1;
                cbCriterio1.Enabled = false;
                miToolTip.SetToolTip(btnBuscar, "Buscar Categoria [F4]");
            }*/
        }

        private void cbCriterio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCodigoNombre.Focus();
            }
        }

        private void cbCriterio1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCodigoNombre.Focus();
            }
        }

        private void cbCriterio1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoNombre.Focus();
        }

        private void txtCodigoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnConsultar_Click(this.btnConsultar, new EventArgs());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbCriterio.SelectedValue;
            if (criterio == 1)
            {
                if (!ExtendForms)
                {
                    var frmProducto = new Producto.FrmIngresarProducto();
                    frmProducto.MdiParent = this.MdiParent;
                    frmProducto.tabControlProducto.SelectedIndex = 1;
                    frmProducto.Edit = true;
                    frmProducto.Extencion = true;
                    ExtendForms = true;
                    frmProducto.Show();
                }
            }
            else
            {
                if (!ExtendForms)
                {
                    var frmCategoria = new Categoria.FrmCategoria();
                    frmCategoria.MdiParent = this.MdiParent;
                    frmCategoria.Extencion = true;
                    frmCategoria.TblCategoria.SelectedIndex = 1;
                    ExtendForms = true;
                    frmCategoria.Show();
                }
            }
        }

        DateTime fecha;
        DateTime fecha2;

        private void btnConsultar_Click(object sender, EventArgs e)
        {
           /* try
            {
                this.dgvInventario.DataSource = this.miBussinesKardex.ConstruccionInventarioProducto(this.txtCodigoNombre.Text, this.dtpFecha1.Value, this.dtpFecha2.Value);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/

            
            bool Search = false;
            //this.RowInventario = 0;
            this.CurrentPage = 1;

            if (Convert.ToInt32(this.cbCriterio.SelectedValue).Equals(1)) // Producto
            {
                if (ValidarNumero(this.txtCodigoNombre.Text)) // codigo producto
                {
                    var arrProducto = miBussinesProducto.ProductoBasico(this.txtCodigoNombre.Text);
                    if (arrProducto.Count != 0)
                    {
                        this.CodigoActual = ((DTO.Clases.Producto)arrProducto[0]).CodigoInternoProducto;
                        this.Iteracion = 2;
                        Search = true;
                    }
                    else
                    {
                        Search = false;
                        OptionPane.MessageInformation("El articulo no existe.");
                    }
                }
                else  /// nombre de producto
                {
                    this.Iteracion = 3;
                    this.NombreActual = this.txtCodigoNombre.Text;
                    Search = true;
                }
            }
            else  // Categoria
            {
                if (Convert.ToInt32(this.cbCriterio.SelectedValue).Equals(2)) // categoria
                {
                    if (ValidarNumero(this.txtCodigoNombre.Text)) // codigo categoria
                    {
                        this.Iteracion = 4;
                        this.CategoriaActual = this.txtCodigoNombre.Text;
                        Search = true;
                    }
                    else
                    {
                        Search = false;
                        var frmCategoria = new Categoria.FrmCategoriaNuevo();
                        this.ExtendForms = true;
                        frmCategoria.Extension = true;
                        frmCategoria.PressBoton = false;
                        frmCategoria.txtConsulta.Text = this.txtCodigoNombre.Text;
                        frmCategoria.ShowDialog();
                    }
                }
                else
                {
                    this.Iteracion = 1;
                    Search = true;
                }
            }

            if (Search)
            {
                fecha = dtpFecha1.Value;
                fecha2 = dtpFecha2.Value;
                this.dgvInventario.AutoGenerateColumns = false;
                this.gbConsultas.Enabled = false;

                miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");

                miThread = new Thread(Consultar);
                miThread.Start();
            }
            


            /*var criterio = (int)cbCriterio.SelectedValue;
            var criterio1 = (int)cbCriterio1.SelectedValue;
            RowInventario = 0;
            CurrentPage = 1;
            if (criterio == 1 && criterio1 == 1)
            {
                Iteracion = 2;
                CodigoActual = txtCodigoNombre.Text;
                try
                {
                    var arrP = miBussinesProducto.ProductoBasico(txtCodigoNombre.Text);
                    var p = new DTO.Clases.Producto();
                    try
                    {
                        p = (DTO.Clases.Producto)arrP[0];
                    }
                    catch (Exception ex0)
                    {
                        OptionPane.MessageInformation("El articulo no existe.");
                    }
                    CodigoActual = p.CodigoInternoProducto;
                    dgvInventario.DataSource = miBussinesInventario.ConsultaInventario
                        (p.CodigoInternoProducto, RowInventario, RowMaxInventario);
                    TotalRows = miBussinesInventario.GetRowsConsultaInventario(txtCodigoNombre.Text);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                if (criterio == 1 && criterio1 == 2)
                {
                    Iteracion = 3;
                    NombreActual = txtCodigoNombre.Text;
                    try
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaInventarioNombre
                            (txtCodigoNombre.Text, RowInventario, RowMaxInventario);
                        TotalRows = miBussinesInventario.GetRowsConsultaInventarioNombre(txtCodigoNombre.Text);
                        if (dgvInventario.RowCount.Equals(0))
                        {
                            OptionPane.MessageInformation("No se encontraron registros con ese nombre.");
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    Iteracion = 4;
                    CategoriaActual = txtCodigoNombre.Text;
                    try
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaInventarioCategoria
                            (txtCodigoNombre.Text, RowInventario, RowMaxInventario);
                        TotalRows = miBussinesInventario.GetRowsConsultaInventarioCategoria(txtCodigoNombre.Text);
                        if (dgvInventario.RowCount.Equals(0))
                        {
                            OptionPane.MessageInformation("No se encontraron registros con esa categoria.");
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            txtCodigoNombre.Text = "";
            ColorearGrid();
            CalcularPaginas();*/
        }

        private bool ValidarNumero(string numero)
        {
            try
            {
                Convert.ToDouble(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventario.RowCount != 0)
            {
                tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
            }
        }

        private void dgvInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!dgvInventario.RowCount.Equals(0))
            {
                bool key = false;
                var precio = 0;
                var KeyAccess = 0;
                double destoAplica = 0.0;
                if (e.KeyChar.Equals((char)Keys.D1))
                {
                    precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells["Venta"].Value.ToString());
                    KeyAccess = 1;
                    //destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["Venta"].Value);
                    key = true;
                }
                else
                {
                    if (e.KeyChar.Equals((char)Keys.D2))
                    {
                        precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells["PMayor"].Value.ToString());
                        destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["DestoMayor"].Value);
                        KeyAccess = 2;
                        key = true;
                    }
                    else
                    {
                        if (e.KeyChar.Equals((char)Keys.D3))
                        {
                            precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells["PDistribuidor"].Value.ToString());
                            destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["DestoDistri"].Value);
                            KeyAccess = 3;
                            key = true;
                        }
                        else
                        {
                            if (e.KeyChar.Equals((char)Keys.D4))
                            {
                                destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["DesctoPrecio4"].Value);
                                KeyAccess = 4;
                                key = true;
                            }
                        }
                    }
                }

                if (key)
                {
                    /*if (!dgvInventario.RowCount.Equals(0))
                    {*/
                        var producto = new DTO.Clases.Producto();
                        producto.CodigoInternoProducto = dgvInventario.CurrentRow.Cells["Codigo"].Value.ToString();
                        producto.Descuento = destoAplica;
                        /*producto.ValorVentaProducto = precio;
                        producto.IdIva = KeyAccess;*/

                        if (ExtendVenta)
                        {
                            if (IsCompra)
                            {
                                CompletaEventos.CapturaEvenTransInvFactProvee(producto);
                            }
                            else
                            {
                                if (IsVenta)
                                {
                                    CompletaEventos.CapEventoTransferProductFact(producto);  //  evento que trasmite a fr venta.
                                }
                                else
                                {
                                    CompletaEventos.CapturaEventom(producto);
                                }
                            }
                            //CompletaEventos.CapturaEventom(producto);
                            this.Close();
                        }
                    //}
                   /* else
                    {
                        OptionPane.MessageInformation("No hay registros para cargar.");
                    }*/
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para cargar.");
            }
        }

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa el Stream de la Imagen de Medida.
        /// </summary>
        private System.IO.Stream ImgCostoStream;

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de color gris de Lote.
        /// </summary>
        private const string ImagenLote = "Aplicacion.Recursos.Iconos.loteGris.png";

        private bool BtnVerCosto = true;
        private bool BtnNoVerCosto = true;


        private bool BtnVerPdistri = true;

        private bool BtnNoVerPdistri = true;

        /// <summary>
        /// Representa el Stream de la Imagen de Medida.
        /// </summary>
        private System.IO.Stream ImgPdistriStream;

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de color gris de Lote.
        /// </summary>
        private const string ImagenPdistri = "Aplicacion.Recursos.Iconos.factura_saldo_gris.jpg";


        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                var page = CurrentPage;
                for (int i = page; i > 1; i--)
                {
                    RowInventario = RowInventario - RowMaxInventario;
                    CurrentPage--;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventario(RowInventario, RowMaxInventario);
                                break;
                            }
                        case 2:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventario(CodigoActual, RowInventario, RowMaxInventario);
                                break;
                            }
                        case 3:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventarioNombre(NombreActual, RowInventario, RowMaxInventario);
                                break;
                            }
                        case 4:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventarioCategoria(CategoriaActual, RowInventario, RowMaxInventario);
                                break;
                            }
                    }
                    ColorearGrid();
                   // lblStatusInventario.Text = CurrentPage + " / " + Pages;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                RowInventario = RowInventario - RowMaxInventario;
                if (RowInventario <= 0)
                    RowInventario = 0;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventario(RowInventario, RowMaxInventario);
                                break;
                            }
                        case 2:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventario(CodigoActual, RowInventario, RowMaxInventario);
                                break;
                            }
                        case 3:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventarioNombre(NombreActual, RowInventario, RowMaxInventario);
                                break;
                            }
                        case 4:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventarioCategoria(CategoriaActual, RowInventario, RowMaxInventario);
                                break;
                            }
                    }
                    ColorearGrid();
                    CurrentPage--;
                //    lblStatusInventario.Text = CurrentPage + " / " + Pages;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (CurrentPage < Pages)
            {
                RowInventario = RowInventario + RowMaxInventario;
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventario(RowInventario, RowMaxInventario);
                                break;
                            }
                        case 2:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventario(CodigoActual, RowInventario, RowMaxInventario);
                                break;
                            }
                        case 3:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventarioNombre(NombreActual, RowInventario, RowMaxInventario);
                                break;
                            }
                        case 4:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventarioCategoria(CategoriaActual, RowInventario, RowMaxInventario);
                                break;
                            }
                    }
                    ColorearGrid();
                    CurrentPage++;
                //    lblStatusInventario.Text = CurrentPage + " / " + Pages;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (CurrentPage < Pages)
            {
                var page = CurrentPage;
                for (int i = page; i < Pages; i++)
                {
                    RowInventario = RowInventario + RowMaxInventario;
                    CurrentPage++;
                }
                try
                {
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventario(RowInventario, RowMaxInventario);
                                break;
                            }
                        case 2:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventario(CodigoActual, RowInventario, RowMaxInventario);
                                break;
                            }
                        case 3:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventarioNombre(NombreActual, RowInventario, RowMaxInventario);
                                break;
                            }
                        case 4:
                            {
                                dgvInventario.DataSource = miBussinesInventario.
                                    ConsultaInventarioCategoria(CategoriaActual, RowInventario, RowMaxInventario);
                                break;
                            }
                    }
                    ColorearGrid();
                    //lblStatusInventario.Text = CurrentPage + " / " + Pages;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void CargarUtilidades()
        {
            miToolTip.SetToolTip(btnConsultar, "Realizar Consulta.");
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Producto.Criterio
            {
                Id = 1,
                Nombre = "Producto"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 2,
                Nombre = "Categoria"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 3,
                Nombre = "Todos"
            });
            cbCriterio.DataSource = lst;

            lst = new List<Producto.Criterio>();
            lst.Add(new Producto.Criterio
            {
                Id = 1,
                Nombre = "Codigo"
            });

            lst.Add(new Producto.Criterio
            {
                Id = 2,
                Nombre = "Contenga Nombre"
            });
        }

        private void Consultar()
        {
            try
            {
                switch (this.Iteracion)
                {
                    case 1:
                        {
                            //this.RowMaxInventario = 18000;
                            this.Tabla = miBussinesKardex.ConstruccionInventario(fecha, fecha2);
                                //miBussinesInventario.ConsultaInventario(RowInventario, RowMaxInventario);
                            //this.TotalRows = miBussinesInventario.GetRowsConsultaInventario();
                            break;
                        }
                    case 2:
                        {
                            this.Tabla = miBussinesKardex.ConstruccionInventarioProducto(CodigoActual, fecha, fecha2);
                                ///miBussinesInventario.ConsultaInventario(this.CodigoActual, RowInventario, RowMaxInventario);
                            //this.TotalRows = miBussinesInventario.GetRowsConsultaInventario(this.CodigoActual);
                            break;
                        }
                    case 3:
                        {
                            //this.Tabla = miBussinesInventario.ConsultaInventarioNombre(this.NombreActual, RowInventario, RowMaxInventario);
                           // this.TotalRows = miBussinesInventario.GetRowsConsultaInventarioNombre(this.NombreActual);
                            break;
                        }
                    case 4:
                        {
                            this.Tabla = miBussinesKardex.ConstruccionInventarioCategoria(CategoriaActual, fecha, fecha2);
                                //miBussinesInventario.ConsultaInventarioCategoria(this.CategoriaActual, RowInventario, RowMaxInventario);
                            //this.TotalRows = miBussinesInventario.GetRowsConsultaInventarioCategoria(this.CategoriaActual);
                            break;
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
            try
            {
                this.dgvInventario.DataSource = this.Tabla;

                txtCodigoNombre.Text = "";
                ColorearGrid();
                CalcularPaginas();

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();

                this.gbConsultas.Enabled = true;

                if (this.Tabla.Rows.Count.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontraron registros.");
                }
                else
                {
                    if (this.ExtendForms_)
                    {
                        this.dgvInventario.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.gbConsultas.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Calcula y muestra el número de paginas devueltas en la consulta.
        /// </summary>
        private void CalcularPaginas()
        {
            Pages = TotalRows / RowMaxInventario;
            if (TotalRows % RowMaxInventario != 0)
                Pages++;
            if (CurrentPage > Pages)
                CurrentPage = 0;
            //lblStatusInventario.Text = CurrentPage + " / " + Pages;
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEventoEditProveedor args)
        {
            try
            {
                ExtendForms = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }

            try
            {
                var producto_ = (DTO.Clases.Producto)args.MiObjeto;
                txtCodigoNombre.Text = producto_.CodigoInternoProducto;
                ExtendForms = false;
                btnConsultar.Focus();
            }
            catch { }
        }

        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                ExtendForms = Convert.ToBoolean(args.MiMarca);
            }
            catch { }

            try
            {
                if (ExtendForms)
                {
                    var categoria_ = (DTO.Clases.Categoria)args.MiMarca;
                    this.txtCodigoNombre.Text = categoria_.CodigoCategoria;
                    this.btnConsultar_Click(this.btnConsultar, new EventArgs());
                }
            }
            catch { }
        }

        public void ColorearGrid()
        {
            var cont = 0;
            foreach (DataGridViewRow row in dgvInventario.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }
    }
}