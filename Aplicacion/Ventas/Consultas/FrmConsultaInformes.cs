using System;
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
using System.Xml.Linq;
using System.IO;

namespace Aplicacion.Ventas.Consultas
{
    public partial class FrmConsultaInformes : Form
    {
        private System.Reflection.Assembly assembly;

        private System.IO.StreamReader streamReader;

        private const string Script = "Aplicacion.Recursos.Documentos.sentencias.txt";

        //private string RutaAplicacion;

        private string Ruta;

        private BussinesCategoria miBussinesCategoria;

        private BussinesConsultaSQL miBussinesConsultaSQL;

        private BussinesRemision miBussinesRemision;

        private string sql;

        DataTable tCategorias;

        DataTable tIvaCategoria;

        DataTable TivaVenta;

        DataTable TivaCompra;
        
        double TotalCosto;



        /*
        private BussinesFacturaVenta miBussinesFactura;

        private BussinesDevolucion miBussDevol;


        private BussinesFacturaProveedor miBussCompra;

        private BussinesUsuario miBussUser;


        private BussinesCliente miBussCliente;*/


        private string codProductos;

        private string codProductosVenta;

        private DateTime FechaActual;

        private DateTime FechaActual2;

        //private int maxValor;

        private Thread miThread;

        private OptionPane miOption;



        DataTable table_1 = new DataTable();

        DataTable table_2 = new DataTable();

        DataTable table_3 = new DataTable();



        DataTable tClientes = new DataTable();

        List<FacturaVenta> lstFacturas = new List<FacturaVenta>();

        public FrmConsultaInformes()
        {
            InitializeComponent();
            try
            {
                //RutaAplicacion = AppConfiguracion.ValorSeccion("report");
                assembly = System.Reflection.Assembly.GetExecutingAssembly();
                this.miBussinesCategoria = new BussinesCategoria();
                this.miBussinesConsultaSQL = new BussinesConsultaSQL();
                this.miBussinesRemision = new BussinesRemision();
                this.sql = "";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

            



            //this.maxValor = 0;
            /*this.miBussinesFactura = new BussinesFacturaVenta();
            this.miBussDevol = new BussinesDevolucion();
            this.miBussCompra = new BussinesFacturaProveedor();
            this.miBussUser = new BussinesUsuario();
            this.miBussCliente = new BussinesCliente();*/
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                txtBaseDatos.Text = AppConfiguracion.ValorSeccion("dataBase");
                this.CargarSqlRemisiones();
                this.CargarCategorias();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            //this.dgvIvaDevoluciones.AutoGenerateColumns = false;
            //this.dgvIvaAnuladas.AutoGenerateColumns = false;
        }

        private void CargarCategorias()
        {
            try
            {
                tCategorias = new DataTable();
                tCategorias.Columns.Add(new DataColumn("codigocategoria", typeof(string)));
                tCategorias.Columns.Add(new DataColumn("nombrecategoria", typeof(string)));
                DataRow nRow = tCategorias.NewRow();
                nRow["codigocategoria"] = "SELECCIONE UNA CATEGORIA";
                nRow["nombrecategoria"] = "SELECCIONE UNA CATEGORIA";
                tCategorias.Rows.Add(nRow);

                foreach (DataRow r in miBussinesCategoria.ListadoCategoria().Rows)
                {
                    nRow = tCategorias.NewRow();
                    nRow["codigocategoria"] = r["codigocategoria"];
                    nRow["nombrecategoria"] = r["nombrecategoria"];
                    tCategorias.Rows.Add(nRow);
                }
                this.cbCategoria.DataSource = tCategorias;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarSqlRemisiones()
        {
            try
            {
                var sentenciasSQL = GetStrigRecurso();
                miBussinesConsultaSQL.ExecuteNonQuery(sentenciasSQL);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private string GetStrigRecurso()
        {
            try
            {
                //var str = RutaAplicacion.Replace('\\', '.') + "." + Script;
                streamReader = new StreamReader(assembly.GetManifestResourceStream(Script));
                if (streamReader.Peek() != -1)
                {
                    return streamReader.ReadToEnd();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                OptionPane.MessageError("Ocurrió un error al cargar el recurso Demo.txt.");
                return null;
            }
        }


        private void btnGuardarConexion_Click(object sender, EventArgs e)
        {
            try
            {
                AppConfiguracion.SaveConfiguration("dataBase", txtBaseDatos.Text);
                this.miBussinesConsultaSQL.NuevaConexion();
                this.miBussinesRemision.NewConection();
                this.CargarSqlRemisiones();
                this.CargarCategorias();
                OptionPane.MessageInformation("La conexion se guardó con éxito.");
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
              /* StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine("25225;AXION BARRA * 125 GR");
                csvContent.AppendLine("25232;ARROZ DIANA * 445 GR");
                string csvPath = "G:\\xyz.csv";
                File.AppendAllText(csvPath, csvContent.ToString());*/




                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar);
                this.miThread.Start();

            }
            catch (Exception ex) { OptionPane.MessageError(ex.Message); }

        }

        private void btnLoadSaldosCarteraF4_Click(object sender, EventArgs e)
        {
            try
            {
                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar_F4);
                this.miThread.Start();
            }
            catch { }
        }

        private void btnLoadSaldosRbo_Click(object sender, EventArgs e)
        {
            try
            {
                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar_Rbo);
                this.miThread.Start();
            }
            catch { }
        }

        private string FuncionEspacio(int lengthEspacio)
        {
            string espacio = "";
            for(int i = 1; i <= lengthEspacio; i++)
            {
                espacio += " ";
            }
            return espacio;
        }

        private void Cargar()
        {
            try
            {
                this.table_1 = this.miBussinesConsultaSQL.Consulta(this.sql);
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar()
        {
            try
            {
                this.dataGrid_1.DataSource = this.table_1; 

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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


        private void Cargar_F4()
        {
            try
            {
                /*this.tClientes.Columns.Add(new DataColumn("cedula", typeof(string)));
                this.tClientes.Columns.Add(new DataColumn("cliente", typeof(string)));
                this.tClientes.Columns.Add(new DataColumn("saldo", typeof(double)));

                var clientesT = this.miBussCliente.ListadoDeClientes();
                foreach (DataRow ctRow in clientesT.Rows)
                {
                    var cRow = tClientes.NewRow();
                    cRow["cedula"] = ctRow["nitcliente"];
                    cRow["cliente"] = ctRow["nombrescliente"];
                    cRow["saldo"] = this.miBussinesFactura.CarteraCliente_(2, ctRow["nitcliente"].ToString()).Sum(s => s.Saldo);
                    tClientes.Rows.Add(cRow);
                }*/

               // this.tClientes = this.miBussinesFactura.ProductosDeVentas(this.lstFacturas);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar_LoadF4));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar_LoadF4));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar_LoadF4()
        {
            try
            {
                //this.dataGrid_2.DataSource = this.tClientes;

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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


        private void Cargar_Rbo()
        {
            try
            {
                /*this.tClientes.Columns.Add(new DataColumn("cedula", typeof(string)));
                this.tClientes.Columns.Add(new DataColumn("cliente", typeof(string)));
                this.tClientes.Columns.Add(new DataColumn("saldo", typeof(double)));

                var clientesT = this.miBussCliente.ListadoDeClientes();
                foreach (DataRow ctRow in clientesT.Rows)
                {
                    var cRow = tClientes.NewRow();
                    cRow["cedula"] = ctRow["nitcliente"];
                    cRow["cliente"] = ctRow["nombrescliente"];
                    cRow["saldo"] = this.miBussinesFactura.SaldoClienteRboIngreso(ctRow["nitcliente"].ToString());
                    tClientes.Rows.Add(cRow);
                }

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar_Rbo));
                }*/
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar_Rbo));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar_Rbo()
        {
            try
            {
                this.dataGrid_1.DataSource = this.tClientes;

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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

        private void btnCsv_Click(object sender, EventArgs e)
        {
            try
            {



                /*
                string data = "";
                StringBuilder csvContent = new StringBuilder();
                for (int regist = 0; regist < table_1.Rows.Count; regist++)
                {
                    for (int column = 0; column < table_1.Columns.Count; column++)
                    {
                        if (column == (table_1.Columns.Count - 1))
                        {
                            data += table_1.Rows[regist][column].ToString();
                        }
                        else
                        {
                            data += table_1.Rows[regist][column].ToString() + ";";
                        }
                    }
                    csvContent.AppendLine(data);
                    data = "";
                }
                string csvPath = "C:\\csv\\xyz.csv";
                File.AppendAllText(csvPath, csvContent.ToString());*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        




        private void btnIvaVentas_Click(object sender, EventArgs e)
        {
            try
            {
                FechaActual = dtpFecha.Value;
                FechaActual2 = dtpFecha2.Value;

                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(CargarIvaVentas);
                this.miThread.Start();

            }
            catch (Exception ex) { OptionPane.MessageError(ex.Message); }

            /*Microsoft.Office.Interop.Excel.Application aplicacion;
            Microsoft.Office.Interop.Excel.Workbook libro;
            Microsoft.Office.Interop.Excel.Worksheet hoja;
            aplicacion = new Microsoft.Office.Interop.Excel.Application();
            libro = aplicacion.Workbooks.Add();
            hoja =
                 (Microsoft.Office.Interop.Excel.Worksheet)libro.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Range r;*/
        }


        private void CargarIvaVentas()
        {
            try
            {
                table_1 = miBussinesConsultaSQL.IvaEnVentas(FechaActual, FechaActual2);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarIvaVentas));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarIvaVentas));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FinalizarIvaVentas()
        {
            try
            {
                this.dataGrid_1.DataSource = this.table_1;

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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



        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    this.Ruta = fichero.FileName;
                    miOption = new OptionPane();
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                    miOption.FrmProgressBar.Closed_ = true;
                    miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                        "Operacion en progreso");
                    miThread = new Thread(SaveExcel);
                    miThread.Start();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void SaveExcel()
        {
            try
            {
                /*
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libro;
                Microsoft.Office.Interop.Excel.Worksheet hoja;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libro = aplicacion.Workbooks.Add();
                hoja =
                     (Microsoft.Office.Interop.Excel.Worksheet)libro.Worksheets.get_Item(1);

                Microsoft.Office.Interop.Excel.Range r;

                // Encabezado
                int iFil = 0, iCol = 0;
                foreach (DataGridViewColumn column in this.dataGrid_1.Columns)
                {
                    hoja.Cells[1, ++iCol] = column.HeaderText;
                    r = (Microsoft.Office.Interop.Excel.Range)hoja.Cells[1, iCol];
                    hoja.get_Range(r, r).Font.Bold = true;
                }

                DateTime fecha;
                string fecha_ = "";
                //  Cuerpo
                for (iFil = 0; iFil < table_1.Rows.Count; iFil++)
                {
                    for (iCol = 0; iCol < table_1.Columns.Count; iCol++)
                    {
                        if (iCol == 0)
                        {
                            fecha = Convert.ToDateTime(table_1.Rows[iFil][iCol]);
                            fecha_ = fecha.Month + "/" + fecha.Day + "/" + fecha.Year;
                            hoja.Cells[iFil + 2, iCol + 1] = fecha_; //Convert.ToDateTime(table_1.Rows[iFil][iCol]); // construir la fecha usando dia, mes y año
                        }
                        else
                        {
                            r = (Microsoft.Office.Interop.Excel.Range)hoja.Cells[iFil + 2, iCol + 1];
                            hoja.Cells[iFil + 2, iCol + 1] = table_1.Rows[iFil][iCol].ToString();
                        }
                    }
                }
                hoja.Columns.AutoFit();
                //libro.SaveAs(Ruta);
                libro.SaveAs(this.Ruta,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libro.Close(true);
                hoja = null;
                libro = null;
                aplicacion.Quit();
                aplicacion = null;*/

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarSaveExcel));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarSaveExcel));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FinalizarSaveExcel()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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


        private void btnIvaDevol_Click(object sender, EventArgs e)
        {
            try
            {
                FechaActual = dtpFecha.Value;
                FechaActual2 = dtpFecha2.Value;

                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(CargarIvaDevoluciones);
                this.miThread.Start();

            }
            catch (Exception ex) { OptionPane.MessageError(ex.Message); }
        }

        private void CargarIvaDevoluciones()
        {
            try
            {
                table_1 = miBussinesConsultaSQL.IvaEnDevoluciones(FechaActual, FechaActual2);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarIvaDevoluciones));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarIvaDevoluciones));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FinalizarIvaDevoluciones()
        {
            try
            {
                this.dataGrid_1.DataSource = this.table_1;

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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


        private void btnIvaCosto_Click(object sender, EventArgs e)
        {
            try
            {
                FechaActual = dtpFecha.Value;
                FechaActual2 = dtpFecha2.Value;

                if (textBox1.Text != "")
                {
                    codProductos = " AND producto_factura_venta.codigointernoproducto != '" + textBox1.Text + "' ";

                    codProductosVenta = " AND ( producto_factura_venta.codigointernoproducto = '" + textBox1.Text + "' ";
                }
                if (textBox2.Text != "")
                {
                    codProductos += " AND producto_factura_venta.codigointernoproducto != '" + textBox2.Text + "' ";

                    codProductosVenta += " OR producto_factura_venta.codigointernoproducto = '" + textBox2.Text + "' ";
                }
                if (textBox3.Text != "")
                {
                    codProductos += " AND producto_factura_venta.codigointernoproducto != '" + textBox3.Text + "' ";

                    codProductosVenta += " OR producto_factura_venta.codigointernoproducto = '" + textBox3.Text + "' ";
                }
                if (textBox4.Text != "")
                {
                    codProductos += " AND producto_factura_venta.codigointernoproducto != '" + textBox4.Text + "' ";

                    codProductosVenta += " OR producto_factura_venta.codigointernoproducto = '" + textBox4.Text + "' ";
                }
                if (textBox5.Text != "")
                {
                    codProductos += " AND producto_factura_venta.codigointernoproducto != '" + textBox5.Text + "' ";

                    codProductosVenta += " OR producto_factura_venta.codigointernoproducto = '" + textBox5.Text + "' ";
                }
                if (textBox6.Text != "")
                {
                    codProductos += " AND producto_factura_venta.codigointernoproducto != '" + textBox6.Text + "' ";

                    codProductosVenta += " OR producto_factura_venta.codigointernoproducto = '" + textBox6.Text + "' ";
                }
                if (textBox7.Text != "")
                {
                    codProductos += " AND producto_factura_venta.codigointernoproducto != '" + textBox7.Text + "' ";

                    codProductosVenta += " OR producto_factura_venta.codigointernoproducto = '" + textBox7.Text + "' ";
                }

                if (codProductosVenta != "")
                {
                    codProductosVenta += " ) ";
                }

                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(CargarIvaCosto);
                this.miThread.Start();

            }
            catch (Exception ex) { OptionPane.MessageError(ex.Message); }
        }

        private void CargarIvaCosto()
        {
            try
            {
                table_2 = miBussinesConsultaSQL.IvaDeCosto(codProductos, FechaActual, FechaActual2);

                table_3 = miBussinesConsultaSQL.IvaVentaParaCosto(codProductosVenta, FechaActual, FechaActual2);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarIvaCosto));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarIvaCosto));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FinalizarIvaCosto()
        {
            try
            {
                dgvCostos.DataSource = table_2;

                dgvVentaCosto.DataSource = table_3;

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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





        private void btnExcelCostos_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    this.Ruta = fichero.FileName;
                    miOption = new OptionPane();
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                    miOption.FrmProgressBar.Closed_ = true;
                    miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                        "Operacion en progreso");
                    miThread = new Thread(SaveExcelCosto);
                    miThread.Start();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void SaveExcelCosto()
        {
            try
            {
                /*
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libro;
                Microsoft.Office.Interop.Excel.Worksheet hoja;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libro = aplicacion.Workbooks.Add();
                hoja =
                     (Microsoft.Office.Interop.Excel.Worksheet)libro.Worksheets.get_Item(1);

                Microsoft.Office.Interop.Excel.Range r;

                // Encabezado
                int iFil = 0, iCol = 0;
                foreach (DataGridViewColumn column in this.dgvCostos.Columns)
                {
                    hoja.Cells[1, ++iCol] = column.HeaderText;
                    r = (Microsoft.Office.Interop.Excel.Range)hoja.Cells[1, iCol];
                    hoja.get_Range(r, r).Font.Bold = true;
                }

                DateTime fecha;
                string fecha_ = "";
                //  Cuerpo
                for (iFil = 0; iFil < table_2.Rows.Count; iFil++)
                {
                    for (iCol = 0; iCol < table_2.Columns.Count; iCol++)
                    {
                        if (iCol == 0)
                        {
                            fecha = Convert.ToDateTime(table_2.Rows[iFil][iCol]);
                            fecha_ = fecha.Month + "/" + fecha.Day + "/" + fecha.Year;
                            hoja.Cells[iFil + 2, iCol + 1] = fecha_; //Convert.ToDateTime(table_1.Rows[iFil][iCol]); // construir la fecha usando dia, mes y año
                        }
                        else
                        {
                            r = (Microsoft.Office.Interop.Excel.Range)hoja.Cells[iFil + 2, iCol + 1];
                            hoja.Cells[iFil + 2, iCol + 1] = table_2.Rows[iFil][iCol].ToString();
                        }
                    }
                }
                hoja.Columns.AutoFit();
                //libro.SaveAs(Ruta);
                libro.SaveAs(this.Ruta,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libro.Close(true);
                hoja = null;
                libro = null;
                aplicacion.Quit();
                aplicacion = null;*/

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarSaveExcelCosto));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarSaveExcelCosto));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FinalizarSaveExcelCosto()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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



        private void btnExcelVentaNoCodigos_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog fichero = new SaveFileDialog();
                fichero.Filter = "Excel (*.xls)|*.xls";
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    this.Ruta = fichero.FileName;
                    miOption = new OptionPane();
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                    miOption.FrmProgressBar.Closed_ = true;
                    miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                        "Operacion en progreso");
                    miThread = new Thread(SaveExcelVentaNoCodigos);
                    miThread.Start();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void SaveExcelVentaNoCodigos()
        {
            try
            {
                /*
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libro;
                Microsoft.Office.Interop.Excel.Worksheet hoja;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libro = aplicacion.Workbooks.Add();
                hoja =
                     (Microsoft.Office.Interop.Excel.Worksheet)libro.Worksheets.get_Item(1);

                Microsoft.Office.Interop.Excel.Range r;

                // Encabezado
                int iFil = 0, iCol = 0;
                foreach (DataGridViewColumn column in this.dgvVentaCosto.Columns)
                {
                    hoja.Cells[1, ++iCol] = column.HeaderText;
                    r = (Microsoft.Office.Interop.Excel.Range)hoja.Cells[1, iCol];
                    hoja.get_Range(r, r).Font.Bold = true;
                }

                DateTime fecha;
                string fecha_ = "";
                //  Cuerpo
                for (iFil = 0; iFil < table_3.Rows.Count; iFil++)
                {
                    for (iCol = 0; iCol < table_3.Columns.Count; iCol++)
                    {
                        if (iCol == 0)
                        {
                            fecha = Convert.ToDateTime(table_3.Rows[iFil][iCol]);
                            fecha_ = fecha.Month + "/" + fecha.Day + "/" + fecha.Year;
                            hoja.Cells[iFil + 2, iCol + 1] = fecha_; //Convert.ToDateTime(table_1.Rows[iFil][iCol]); // construir la fecha usando dia, mes y año
                        }
                        else
                        {
                            r = (Microsoft.Office.Interop.Excel.Range)hoja.Cells[iFil + 2, iCol + 1];
                            hoja.Cells[iFil + 2, iCol + 1] = table_3.Rows[iFil][iCol].ToString();
                        }
                    }
                }
                hoja.Columns.AutoFit();
                //libro.SaveAs(Ruta);
                libro.SaveAs(this.Ruta,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libro.Close(true);
                hoja = null;
                libro = null;
                aplicacion.Quit();
                aplicacion = null;*/

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarSaveExcelVentaNoCodigos));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarSaveExcelVentaNoCodigos));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FinalizarSaveExcelVentaNoCodigos()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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



        private void btnConsultaCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                //var idsCategoria = txtIdCategoria.Text.Split('-');
                //idsCategoria.s
                if (String.IsNullOrEmpty(txtIdCategoria.Text)) //(idsCategoria.Count() == 0)  // sin id categoria, consulta por filtro nombre
                {
                    var filtro = txtCategoria.Text.Split('-');
                    tIvaCategoria = miBussinesConsultaSQL.ConsultaIvaCategorias(dtpFecha.Value, dtpFecha2.Value, filtro);
                }
                else 
                {
                    var filtro = txtIdCategoria.Text.Split('-');
                    tIvaCategoria =
                        miBussinesConsultaSQL.ConsultaIvaCategoriasFiltroCat(dtpFecha.Value, dtpFecha2.Value, filtro);

                   /* if (idsCategoria.Count() == 1) // 1 solo id categoria, consulta por id categoria
                    {
                        var filtro = txtIdCategoria.Text.Split('-');
                        tIvaCategoria =
                            miBussinesConsultaSQL.ConsultaIvaCategoriasFiltroCat(dtpFecha.Value, dtpFecha2.Value, filtro);
                    }
                    else   //  varios ids de categoria, consulta con ids de categoria (OR)
                    {

                    }*/
                }
                dgIvaCategoria.DataSource = tIvaCategoria;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtIdCategoria.Text += cbCategoria.SelectedValue.ToString() + "-";
        }

        private void btnLimpiarTxtId_Click(object sender, EventArgs e)
        {
            this.txtIdCategoria.Text = "";
        }



        private void btnBuscarRemisiones_Click(object sender, EventArgs e)
        {
            try
            {
                FechaActual = dtpFecha.Value;
                FechaActual2 = dtpFecha2.Value;

                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(CargarRemision);
                this.miThread.Start();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarRemision()
        {
            try
            {
                TivaVenta = miBussinesRemision.ResumenIvaVentas(FechaActual, FechaActual2);
                TivaCompra = miBussinesRemision.ResumenIvaCompras(FechaActual, FechaActual2);
                TotalCosto = miBussinesRemision.TotalCostoVenta(FechaActual, FechaActual2);

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarRemision));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(FinalizarRemision));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FinalizarRemision()
        {
            try
            {
                dgvIvaVenta.DataSource = TivaVenta;
                dgvIvaCompras.DataSource = TivaCompra;
                txtVentas.Text = UseObject.InsertSeparatorMil(TivaVenta.AsEnumerable().Sum(s => s.Field<double>("total")).ToString());
                txtCosto.Text = UseObject.InsertSeparatorMil(Math.Round(TotalCosto, 0).ToString());
                txtDiferencia.Text = UseObject.InsertSeparatorMil((
                    UseObject.RemoveSeparatorMil(txtVentas.Text) - UseObject.RemoveSeparatorMil(txtCosto.Text)).ToString());

                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
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