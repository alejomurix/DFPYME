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
using SpreadsheetLight;

namespace Aplicacion.Ventas
{
    public partial class Form5 : Form
    {
        private BussinesConsultaSQL miBussinesConsultaSQL;

        private string sql;

        private DataTable table_1 = new DataTable();





        private BussinesFacturaVenta miBussinesFactura;

        private BussinesDevolucion miBussDevol;


        private BussinesFacturaProveedor miBussCompra;

        private BussinesUsuario miBussUser;


        private BussinesCliente miBussCliente;


        private DateTime FechaActual;

        private DateTime FechaActual2;

        private int maxValor;

        private Thread miThread;

        private OptionPane miOption;

        

        DataTable table_2 = new DataTable();

        DataTable table_3 = new DataTable();

        DataTable tClientes = new DataTable();

        List<FacturaVenta> lstFacturas = new List<FacturaVenta>();

        public Form5()
        {
            InitializeComponent();
            this.miBussinesConsultaSQL = new BussinesConsultaSQL();
            this.sql = "";


            //this.maxValor = 0;
            /*this.miBussinesFactura = new BussinesFacturaVenta();
            this.miBussDevol = new BussinesDevolucion();
            this.miBussCompra = new BussinesFacturaProveedor();
            this.miBussUser = new BussinesUsuario();
            this.miBussCliente = new BussinesCliente();*/
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //this.dgvIvaDevoluciones.AutoGenerateColumns = false;
            //this.dgvIvaAnuladas.AutoGenerateColumns = false;
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


                this.sql = this.txtSql.Text;


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
                this.tClientes.Columns.Add(new DataColumn("cedula", typeof(string)));
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
                }
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
                string data = "";
                //StringBuilder csvContent = new StringBuilder();
               // csvContent.Append("45445;");
                //csvContent.AppendLine("1");
                /*csvContent.AppendLine("25225;AXION BARRA * 125 GR");
                csvContent.AppendLine("25232;ARROZ DIANA * 445 GR");
                string csvPath = "G:\\xyz.csv";
                File.AppendAllText(csvPath, csvContent.ToString());*/
                
                
                /**
                 * for (int regist = 0; regist < table_1.Rows.Count; regist++)
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
                */

                /*for (int column = 0; column < table_1.Columns.Count; column++)
                {
                    for (int regist = 0; regist < table_1.Rows.Count; regist++) 
                    {
                        if (regist == (table_1.Rows.Count + 1))
                        {
                            csvContent.AppendLine(table_1.Rows[regist][column].ToString());
                        }
                        else
                        {
                            csvContent.Append(table_1.Rows[regist][column].ToString() + ";");
                        }
                    }
                }*/
                /*foreach (DataRow dRow in table_1.Rows)
                {
                    for (int i = 0; i < table_1.Columns.Count; i++)
                    {

                    }
                    csvContent.AppendLine(dRow[0].ToString() + ";" +
                                          dRow[1].ToString() + ";" +
                                          dRow[2].ToString() + ";" +
                                          dRow[3].ToString() + ";" +
                                          dRow[4].ToString() + ";" +
                                          dRow[5].ToString() + ";" +
                                          dRow[6].ToString() + ";" +
                                          dRow[7].ToString() + ";" +
                                          dRow[8].ToString() + ";" +
                                          dRow[9].ToString() + ";" +
                                          dRow[10].ToString() + ";" +
                                          dRow[11].ToString() + ";" +
                                          dRow[12].ToString() + ";" +
                                          dRow[13].ToString());
                }*/
                //string csvPath = "C:\\csv\\xyz.csv";

                if (this.table_1.Rows.Count > 0)
                {
                    miOption = new OptionPane();
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                    miOption.FrmProgressBar.Closed_ = true;
                    miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                        "Operacion en progreso");
                    miThread = new Thread(SaveExcel);
                    miThread.Start();
                    //SaveExcel();
                }
                
                //OptionPane.MessageInformation("Archivo generado correctamente.");

                //string csvPath = "C:\\csv\\xyz.xlsx";
                ///File.AppendAllText(csvPath, csvContent.ToString());
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
                //var empresa = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                int fila = 1, columna = 1;
                SLDocument sld = new SLDocument();
                foreach (DataRow row in this.table_1.Rows)
                {
                    columna = 1;
                    sld.SetCellValue(fila, columna, row[0].ToString());
                    columna++;
                    sld.SetCellValue(fila, columna, row[1].ToString());
                    columna++;
                    sld.SetCellValue(fila, columna, row[2].ToString());
                    columna++;
                    sld.SetCellValue(fila, columna, row[3].ToString());
                    columna++;
                    sld.SetCellValue(fila, columna, row[4].ToString());
                    columna++;
                    sld.SetCellValue(fila, columna, row[5].ToString());
                    columna++;

                    //var fecha = Convert.ToDateTime(row[6]).ToShortDateString();

                    sld.SetCellValue(fila, columna, Convert.ToDateTime(row[6]).ToShortDateString()); // fecha
                    columna++;

                    //var hora_ = Convert.ToDateTime(row[7]).TimeOfDay.ToString();
                    //var hora = hora_.TimeOfDay.ToString();
                    //var hstr = hora.
                    sld.SetCellValue(fila, columna, Convert.ToDateTime(row[7]).TimeOfDay.ToString()); // hora
                    columna++;
                    sld.SetCellValue(fila, columna, row[8].ToString());
                    columna++;
                    sld.SetCellValue(fila, columna, row[9].ToString());
                    columna++;
                    sld.SetCellValue(fila, columna, row[10].ToString());
                    
                    fila++;
                }

                /*
                for (fila = 0; fila <= this.table_1.Rows.Count - 1; fila++)
                {
                    columna = 1;
                    sld.SetCellValue(fila, columna, ConsImpuesto[].NitTercero);
                    columna++;
                }*/



                /**
                sld.SetCellValue(1, 1, RowEmpresa["Nombre"].ToString());
                sld.SetCellValue(2, 1, RowEmpresa["Juridico"].ToString());
                sld.SetCellValue(3, 1, RowEmpresa["Nit"].ToString());
                sld.SetCellValue(4, 1, RowEmpresa["Direccion"].ToString());
                sld.SetCellValue(5, 1, "");
                sld.SetCellValue(6, 1, "INFORME DE VENTAS");
                if (this.IdSelectDate.Equals(1))
                {
                    sld.SetCellValue(7, 1, "Fecha " + this.Fecha1.ToShortDateString());
                }
                else
                {
                    sld.SetCellValue(7, 1, "Periodo " + this.Fecha1.ToShortDateString() + " a " + this.Fecha2.ToShortDateString());
                }
                sld.SetCellValue(8, 1, "");
                sld.SetCellValue(9, 1, "IDENTIFICACIÓN");
                sld.SetCellValue(9, 2, "TERCERO");
                sld.SetCellValue(9, 3, "NÚMERO");
                sld.SetCellValue(9, 4, "FECHA");
                sld.SetCellValue(9, 5, "BASE 0");
                sld.SetCellValue(9, 6, "IVA 0");
                sld.SetCellValue(9, 7, "BASE 5");
                sld.SetCellValue(9, 8, "IVA 5");
                sld.SetCellValue(9, 9, "ICO BASE 5");
                sld.SetCellValue(9, 10, "BASE 19");
                sld.SetCellValue(9, 11, "IVA 19");
                sld.SetCellValue(9, 12, "ICO BASE 19");
                sld.SetCellValue(9, 13, "BASE 1E007");
                sld.SetCellValue(9, 14, "IVA 1E007");
                sld.SetCellValue(9, 15, "INC BOLSA");
                sld.SetCellValue(9, 16, "RETENCIÓN");
                sld.SetCellValue(9, 17, "TOTAL");
                sld.SetCellValue(9, 18, "DESCUENTO");
                sld.SetCellValue(9, 19, "BASE COSTO DE VENTA");
                string fecha_ = "";
                for (fila = 10; fila <= ConsImpuesto.Count + 9; fila++)
                {
                    columna = 1;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].NitTercero);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Tercero);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Numero);
                    columna++;
                    fecha_ = ConsImpuesto[fila - 10].Fecha.Day + "/" + ConsImpuesto[fila - 10].Fecha.Month + "/" + ConsImpuesto[fila - 10].Fecha.Year;
                    sld.SetCellValue(fila, columna, fecha_);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Base0);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Iva0);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Base5);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Iva5);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].IcoBase5);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Base19);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Iva19);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].IcoBase19);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Base1E);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Iva1E);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].IncBolsa);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Retencion);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Total);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].Descuento);
                    columna++;
                    sld.SetCellValue(fila, columna, ConsImpuesto[fila - 10].CostoVenta);
                    columna++;
                }
                */


                sld.SaveAs("C:\\csv\\xyz.xlsx");
                sld.Dispose();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(EndSaveExcel));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(EndSaveExcel));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void EndSaveExcel()
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

        private void txtTotalBaseIvaCosto_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}