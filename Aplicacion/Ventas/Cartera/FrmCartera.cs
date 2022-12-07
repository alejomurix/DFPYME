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

namespace Aplicacion.Ventas.Cartera
{
    public partial class FrmCartera : Form
    {
        private DataTable Tabla { set; get; }

        private int NombreWith { set; get; }

        private int CriterioPrint { set; get; }

        private string ClientePrint { set; get; }

        private BussinesCliente miBussinesCliente;

        private BussinesFacturaVenta miBussinesFactura;

        private Thread miThread;

        private OptionPane miOption;


        private int RowIndex;

        private int RowMax;

        private long TotalRow;

       // private long Paginas;

       // private int CurrentPage;

       // private int Iterador;


        public FrmCartera()
        {
            InitializeComponent();
            this.Tabla = new DataTable();
            this.Tabla.TableName = "Cartera";
            this.Tabla.Columns.Add(new DataColumn("cedula", typeof(string)));
            this.Tabla.Columns.Add(new DataColumn("nombre", typeof(string)));
            this.Tabla.Columns.Add(new DataColumn("id", typeof(int)));
            this.Tabla.Columns.Add(new DataColumn("factura", typeof(string)));
            this.Tabla.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
            this.Tabla.Columns.Add(new DataColumn("limite", typeof(DateTime)));
            this.Tabla.Columns.Add(new DataColumn("idestado", typeof(int)));
            this.Tabla.Columns.Add(new DataColumn("valor", typeof(int)));
            this.Tabla.Columns.Add(new DataColumn("abonos", typeof(int)));
            this.Tabla.Columns.Add(new DataColumn("saldo", typeof(int)));

            NombreWith = Nombre.Width;
            this.CriterioPrint = 2;
            this.ClientePrint = "";
            miBussinesCliente = new BussinesCliente();
            miBussinesFactura = new BussinesFacturaVenta();

            this.RowMax = 200;
        }

        private void FrmCartera_Load(object sender, EventArgs e)
        {
            CargarComponentes();
            this.dgvCartera.AutoGenerateColumns = false;
            CompletaEventos.Completabo += new CompletaEventos.CompletaAccionbo(CompletaEventos_Completabo);

        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCartera.RowCount != 0)
                {
                    /*if (!rta.Equals(DialogResult.Cancel))
                    {*/
                        //var tabla = new DataTable();
                       /* switch (CriterioPrint)
                        {
                            case 1:
                                {
                                    //tabla = miBussinesFactura.CarteraClientes(false, false, null);
                                    break;
                                }
                            case 2:
                                {
                                    //Tabla = miBussinesFactura.CarteraClientes(true, false, null);
                                    //this.Tabla = this.miBussinesFactura.CarteraDeClientes(2);
                                    break;
                                }
                            case 3:
                                {
                                    //Tabla = miBussinesFactura.CarteraClientes(false, true, this.txtConsulta.Text);
                                    //this.Tabla = this.miBussinesFactura.CarteraDeClientes(2, this.ClientePrint);
                                    break;
                                }
                        }*/

                        var frmPrint = new FrmPrintCartera();
                        frmPrint.Tamanio = Imprimir.TamanioPapel.CartaHorizontal;
                        frmPrint.Reporte = "CARTERA DE CLIENTES.";
                        frmPrint.Tabla = this.Tabla;
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraCliente")))
                        {
                            frmPrint.PrintPos(false);
                        }
                        else
                        {
                            FrmPrint frmPrint_ = new FrmPrint();
                            frmPrint_.StringCaption = "Cartera de Clientes";
                            frmPrint_.StringMessage = "Impresión de Cartera de Clientes";
                            DialogResult rta = frmPrint_.ShowDialog();

                            if (!rta.Equals(DialogResult.Cancel))
                            {
                                frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\CarteraDeClientes.rdlc";
                                //frmPrint.ReportPath = @"C:\reports\CarteraDeClientes.rdlc";

                               // frmPrint.ReportPath = 
                            //    @"C:\Users\alejo\Documents\Visual Studio 2010\Projects\DFPYME\DFPYME\Aplicacion\Ventas\Reportes\CarteraDeClientes.rdlc";
                                if (rta.Equals(DialogResult.No))
                                {
                                    frmPrint.ShowDialog();
                                }
                                else
                                {
                                    if (rta.Equals(DialogResult.Yes))
                                    {
                                        Imprimir print = new Imprimir();
                                        print.Report = frmPrint.Load_();
                                        print.Print(Imprimir.TamanioPapel.CartaHorizontal);
                                        frmPrint.ResetReport();
                                    }
                                }
                            }
                        }
                    //}
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

        //
        private void tsBtnImprimirResumen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Tabla.Rows.Count > 0)
                {
                    var query = from data in this.Tabla.AsEnumerable()
                                group data by new
                                {
                                    Cedula = data.Field<string>("cedula"),
                                    Nombre = data.Field<string>("nombre")
                                }
                                    into grupo
                                    select new
                                    {
                                        Cedula = grupo.Key.Cedula,
                                        Nombre = grupo.Key.Nombre,
                                        Saldo = grupo.Sum(s => s.Field<int>("saldo"))
                                    };
                    var tabla = new DataTable();
                    tabla.Columns.Add(new DataColumn("Cedula", typeof(string)));
                    tabla.Columns.Add(new DataColumn("Nombre", typeof(string)));
                    tabla.Columns.Add(new DataColumn("Saldo", typeof(int)));

                    foreach (var row_ in query)
                    {
                        var row = tabla.NewRow();
                        row["Cedula"] = row_.Cedula;
                        row["Nombre"] = row_.Nombre;
                        row["Saldo"] = row_.Saldo;
                        tabla.Rows.Add(row);
                    }

                    var frmPrint = new FrmPrintCartera();
                    frmPrint.Tamanio = Imprimir.TamanioPapel.Carta;
                    frmPrint.Reporte = "RESUMEN CARTERA DE CLIENTES.";
                    // frmPrint.Tabla = miBussinesFactura.ResumenCarteraClientes(false);
                    frmPrint.Tabla = tabla;
                    frmPrint.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\ResumenCarteraDeClientes.rdlc";
                   // frmPrint.ReportPath = @"C:\reports\ResumenCarteraDeClientes.rdlc";

                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("printCarteraCliente")))
                    {
                        frmPrint.PrintPos(true);
                    }
                    else
                    {
                        FrmPrint frmPrint_ = new FrmPrint();
                        frmPrint_.StringCaption = "Cartera de Clientes";
                        frmPrint_.StringMessage = "Impresión de Cartera de Clientes";
                        DialogResult rta = frmPrint_.ShowDialog();
                        if (rta.Equals(DialogResult.No))
                        {
                            frmPrint.ShowDialog();
                        }
                        else
                        {
                            if (rta.Equals(DialogResult.Yes))
                            {
                                Imprimir print = new Imprimir();
                                print.Report = frmPrint.Load_();
                                print.Print(Imprimir.TamanioPapel.Carta);
                                frmPrint.ResetReport();
                            }
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No hay consulta para imprimir.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnPrintPos_Click(object sender, EventArgs e)
        {
            /*try
            {
                var frmPrint = new FrmPrintCartera();
                frmPrint.Reporte = "RESUMEN CARTERA DE CLIENTES.";
                frmPrint.Tabla = miBussinesFactura.ResumenCarteraClientes(false);
                frmPrint.PrintPos();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbContado_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConsulta.Text = "";
            txtConsulta.Focus();
        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(3))
            {
                var frmCliente = new Cliente.frmCliente();
                frmCliente.tcClientes.SelectTab(1);
                frmCliente.ConsultaVenta = true;
                frmCliente.ShowDialog();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           /* try
            {
                this.bs.DataSource = this.miBussinesFactura.CarteraCliente(2, this.txtConsulta.Text);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/

            CriterioPrint = Convert.ToInt32(cbCriterio.SelectedValue);
          //  dgvCartera.AutoGenerateColumns = false;

            this.txtConsulta.Enabled = false;
            this.btnBuscarCliente.Enabled = false;
            this.btnBuscar.Enabled = false;

            miOption = new OptionPane();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
            miOption.FrmProgressBar.Closed_ = true;
            miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                "Operacion en progreso");
            miThread = new Thread(Consultar);
            miThread.Start();

            /**
            miThread.Join();

            dgvCartera.DataSource = Tabla;// query.ToList(); // Tabla;
            //var s_ = Tabla.AsEnumerable().Sum(s => s.Field<double>("Saldo"));
            txtTotal.Text = UseObject.InsertSeparatorMil(Tabla.AsEnumerable().Sum(s => s.Field<int>("Saldo")).ToString());
            if (dgvCartera.Rows.Count > 15 && NombreWith.Equals(Nombre.Width))
            {
                dgvCartera.Columns["Nombre"].Width = Nombre.Width - 5;
            }
            if (dgvCartera.RowCount != 0)
            {
                SaldoDeCliente();
            }
            ColorGrid();
            ColorSaldoLimite();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();

            this.txtConsulta.Enabled = true;
            this.btnBuscarCliente.Enabled = true;
            this.btnBuscar.Enabled = true;
            */
            
            ///
            //Consultar();

            /*
            try
            {
                var id = Convert.ToInt32(cbCriterio.SelectedValue);
                CriterioPrint = id;
                dgvCartera.AutoGenerateColumns = false;
                switch (id)
                {
                    case 1:
                        {
                            this.ClientePrint = "";
                            Tabla = miBussinesFactura.CarteraClientes(false, false, null);
                            break;
                        }
                    case 2:
                        {
                            this.ClientePrint = "";
                            Tabla = miBussinesFactura.CarteraClientes(true, false, null);
                            break;
                        }
                    case 3:
                        {
                            //var tCliente = miBussinesCliente.ConsultaClienteNit(this.txtConsulta.Text);
                            //if (tCliente.Rows.Count != 0)
                            //{
                                //this.ClientePrint = txtConsulta.Text;
                                //Tabla = miBussinesFactura.CarteraClientes(false, true, this.txtConsulta.Text);
                            //}
                            Tabla = miBussinesFactura.CarteraClientes(false, true, this.txtConsulta.Text);
                            break;
                        }
                }
                dgvCartera.DataSource = Tabla;
                txtTotal.Text = UseObject.InsertSeparatorMil(Tabla.AsEnumerable().Sum(s => s.Field<int>("Saldo")).ToString());
                if (dgvCartera.Rows.Count > 15 && NombreWith.Equals(Nombre.Width))
                {
                    dgvCartera.Columns["Nombre"].Width = Nombre.Width - 5;
                }
                if (dgvCartera.RowCount != 0)
                {
                    SaldoDeCliente();
                }
                ColorGrid();
                ColorSaldoLimite();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            */
        }

        private void dgvCartera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SaldoDeCliente();
        }

        private void dgvCartera_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ColorGrid();
            ColorSaldoLimite();
        }

        private void dgvCartera_KeyUp(object sender, KeyEventArgs e)
        {
            SaldoDeCliente();
        }

        /*private DataTable CarteraPorCliente(string cliente)
        {
           // var tabla = new DataTable();
            try
            {
                var tCliente = miBussinesCliente.ConsultaClienteNit(cliente);
                if (tCliente.Rows.Count != 0)
                {
                    txtConsulta.Text = "";
                    return miBussinesFactura.CarteraClientes(false, true, cliente);
                }
                else
                {
                    var frmCliente = new Cliente.frmCliente();
                    frmCliente.ConsultaVenta = true;
                    frmCliente.SubConsulta = true;
                    frmCliente.txtParametro.Text = cliente;
                    frmCliente.ShowDialog();
                    //return new DataTable();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return new DataTable();
            }
        }*/

        private void CargarComponentes()
        {
            var lst = new List<Inventario.Producto.Criterio>();
          /*  lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Todos los Clientes"
            });*/
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Clientes con saldo"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Cliente"
            });
            cbCriterio.DataSource = lst;
        }

        private void ColorGrid()
        {
            var cont = 0;
            foreach (DataGridViewRow gRow in dgvCartera.Rows)
            {
                if (cont % 2 == 0)
                {
                    gRow.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
                cont++;
            }
        }

        private void ColorSaldoLimite()
        {
            foreach (DataGridViewRow gRow in dgvCartera.Rows)
            {
                if (Convert.ToDateTime(gRow.Cells["Limite"].Value) < DateTime.Now &&
                    Convert.ToInt32(gRow.Cells["Saldo"].Value) != 0)
                {
                    gRow.Cells["Saldo"].Style.ForeColor = Color.Red;
                }
            }
        }

        private void SaldoDeCliente()
        {
            if (dgvCartera.RowCount != 0)
            {
                var cedula = dgvCartera.CurrentRow.Cells["Cedula"].Value.ToString();
                txtNombre.Text = dgvCartera.CurrentRow.Cells["Nombre"].Value.ToString();
                txtSaldoCliente.Text = UseObject.InsertSeparatorMil(
                    Tabla.AsEnumerable().Where(d => d.Field<string>("Cedula").Equals(cedula)).Sum(s => s.Field<int>("Saldo")).ToString());
            }
        }

        void CompletaEventos_Completabo(CompletaArgumentosDeEventobo args)
        {
            try
            {
                this.txtConsulta.Text = (string)args.MiBodegabo;
            }
            catch { }
        }

        private void Consultar()
        {
            try
            {
                switch (CriterioPrint)
                {
                    case 1:
                        {
                            this.ClientePrint = "";
                            Tabla = miBussinesFactura.CarteraClientes(false, false, null);
                            break;
                        }
                    case 2:
                        {
                            //this.ClientePrint = "";
                           /* this.Tabla = new DataTable();
                            this.Tabla.TableName = "Cartera";
                            this.Tabla.Columns.Add(new DataColumn("cedula", typeof(string)));
                            this.Tabla.Columns.Add(new DataColumn("nombre", typeof(string)));
                            this.Tabla.Columns.Add(new DataColumn("id", typeof(int)));
                            this.Tabla.Columns.Add(new DataColumn("factura", typeof(string)));
                            this.Tabla.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
                            this.Tabla.Columns.Add(new DataColumn("limite", typeof(DateTime)));
                            this.Tabla.Columns.Add(new DataColumn("idestado", typeof(int)));
                            this.Tabla.Columns.Add(new DataColumn("valor", typeof(int)));
                            this.Tabla.Columns.Add(new DataColumn("abonos", typeof(int)));
                            this.Tabla.Columns.Add(new DataColumn("saldo", typeof(int)));

                            this.RowIndex = 0;
                            this.TotalRow = this.miBussinesFactura.CountCarteraDeClientes(2);

                            double div_ = Convert.ToDouble(TotalRow) / Convert.ToDouble(RowMax);
                            double convert_ = Convert.ToDouble(TotalRow / RowMax);
                            double mathRound = Math.Round(Convert.ToDouble(TotalRow / RowMax), 1);

                            int vuelta = UseObject.DoubleToInt(Math.Round((Convert.ToDouble(TotalRow) / Convert.ToDouble(RowMax)), 1));
                            for (int i = 0; i < vuelta; i++)
                            {
                                var tData = this.miBussinesFactura.CarteraDeClientes(2, RowIndex, RowMax);
                                foreach (DataRow row in tData.Rows)
                                {
                                    var tRow = this.Tabla.NewRow();
                                    tRow["cedula"] = row["cedula"];
                                    tRow["nombre"] = row["nombre"];
                                    tRow["id"] = row["id"];
                                    tRow["factura"] = row["factura"];
                                    tRow["fecha"] = row["fecha"];
                                    tRow["limite"] = row["limite"];
                                    tRow["idestado"] = row["idestado"];
                                    tRow["valor"] = Convert.ToInt32(row["valor"]);
                                    tRow["abonos"] = Convert.ToInt32(row["abonos"]);
                                    tRow["saldo"] = Convert.ToInt32(row["saldo"]);
                                    this.Tabla.Rows.Add(tRow);
                                }
                                this.RowIndex = this.RowIndex + this.RowMax;
                            }*/

                            //this.Tabla = this.miBussinesFactura.CarteraDeClientes(2);

                          /*  this.RowIndex = 0;
                            this.CurrentPage = 1;
                            this.Tabla = this.miBussinesFactura.CarteraDeClientes(2, RowIndex, RowMax);
                            this.TotalRow = this.miBussinesFactura.CountCarteraDeClientes(2);
                            CalcularPaginas();*/


                            // Edición ajuste redondeo de TotalMasIva  16-04-2017
                            //this.ClientePrint = "";
                            //Tabla = miBussinesFactura.CarteraClientes(true, false, null);
                            //

                            // Edición ajuste a mejoras de consulta  25/09/2017
                            ///Tabla = this.miBussinesFactura.CarteraClientes(2);
                            Tabla = this.miBussinesFactura.CarteraClientes(true, false, null);

                            break;
                        }
                    case 3:
                        {
                            this.ClientePrint = this.txtConsulta.Text;
                            Tabla = miBussinesFactura.CarteraClientes(false, true, this.txtConsulta.Text);
                            //this.Tabla = this.miBussinesFactura.CarteraDeClientes(2, this.ClientePrint);
                            break;
                        }
                }
               // Finalizar();
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
            try
            {
               /* var query = from item in Tabla.AsEnumerable()
                            group item by new
                            {
                                Cedula = item.Field<string>("cedula"),
                                Nombre = item.Field<string>("nombre"),
                                Regimen_ = item.Field<string>("regimen"),
                                Direccion = item.Field<string>("direccion"),
                                Ciudad = item.Field<string>("ciudad"),
                                Depto = item.Field<string>("depto")
                            }
                                into it
                                select new
                                {
                                    it.Key.Cedula,
                                    it.Key.Nombre,
                                    it.Key.Regimen_,
                                    it.Key.Direccion,
                                    it.Key.Ciudad,
                                    it.Key.Depto,
                                    Valor_ = it.Sum(s => Convert.ToInt32(s.ItemArray[11])),
                                    V_iva = it.Sum(s => Convert.ToInt32(s.ItemArray[12])),
                                    Abono = it.Sum(s => Convert.ToInt32(s.ItemArray[13])),
                                    Saldo = it.Sum(s => Convert.ToInt32(s.ItemArray[14]))
                                };*/

                dgvCartera.DataSource = Tabla;// query.ToList(); // Tabla;
                //var s_ = Tabla.AsEnumerable().Sum(s => s.Field<double>("Saldo"));
                txtTotal.Text = UseObject.InsertSeparatorMil(Tabla.AsEnumerable().Sum(s => s.Field<int>("Saldo")).ToString());
                if (dgvCartera.Rows.Count > 15 && NombreWith.Equals(Nombre.Width))
                {
                    dgvCartera.Columns["Nombre"].Width = Nombre.Width - 5;
                }
                if (dgvCartera.RowCount != 0)
                {
                    SaldoDeCliente();
                }
                ColorGrid();
                ColorSaldoLimite();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();

                this.txtConsulta.Enabled = true;
                this.btnBuscarCliente.Enabled = true;
                this.btnBuscar.Enabled = true;

               // this.Enabled = true;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();

                this.txtConsulta.Enabled = true;
                this.btnBuscarCliente.Enabled = true;
                this.btnBuscar.Enabled = true;

                //this.Enabled = true;
            }
        }

        private void FrmCartera_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (rta.Equals("1002-105-AJUST"))
                {
                    try
                    {
                        miBussinesFactura.AjustarCartera(Tabla);
                        OptionPane.MessageInformation("El ajuste se realizó con éxito");
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

     /*   private void CalcularPaginas()
        {
            Paginas = TotalRow / RowMax;
            if (TotalRow % RowMax != 0)
                Paginas++;
            if (CurrentPage > Paginas)
                CurrentPage = 0;
            lblStatusFactura.Text = CurrentPage + " / " + Paginas;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentPage > 1)
                {
                    var paginaActual = this.CurrentPage;
                    for (int i = paginaActual; i > 1; i--)
                    {
                        this.RowIndex = this.RowIndex - this.RowMax;
                        this.CurrentPage--;
                    }
                    this.Tabla = this.miBussinesFactura.CarteraDeClientes(2, RowIndex, RowMax);

                    this.lblStatusFactura.Text = this.CurrentPage + " / " + this.Paginas;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentPage > 1)
                {
                    this.RowIndex = this.RowIndex - this.RowMax;
                    if (this.RowIndex <= 0)
                        this.RowIndex = 0;
                    this.Tabla = this.miBussinesFactura.CarteraDeClientes(2, RowIndex, RowMax);

                    this.CurrentPage--;
                    this.lblStatusFactura.Text = this.CurrentPage + " / " + this.Paginas;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentPage < this.Paginas)
                {
                    this.RowIndex = this.RowIndex + this.RowMax;
                    this.Tabla = this.miBussinesFactura.CarteraDeClientes(2, RowIndex, RowMax);

                    this.CurrentPage++;
                    this.lblStatusFactura.Text = this.CurrentPage + " / " + this.Paginas;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CurrentPage < this.Paginas)
                {
                    var paginaActual = this.CurrentPage;
                    for (int i = paginaActual; i < Paginas; i++)
                    {
                        this.RowIndex = this.RowIndex + this.RowMax;
                        this.CurrentPage++;
                    }
                    this.Tabla = this.miBussinesFactura.CarteraDeClientes(2, RowIndex, RowMax);

                    this.lblStatusFactura.Text = this.CurrentPage + " / " + this.Paginas;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }*/
    }
}