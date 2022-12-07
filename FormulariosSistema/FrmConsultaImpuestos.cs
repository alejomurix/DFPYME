using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using SpreadsheetLight;
using Utilities;

namespace FormulariosSistema
{
    public partial class FrmConsultaImpuestos : Form
    {
        public DateTime Fecha1 { set; get; }

        public DateTime Fecha2 { set; get; }

        public Thread miThread { set; get; }

        public int CriterioEstado { set; get; }

        public int CriterioTercero { set; get; }

        public int CriterioFecha { set; get; }

        public OptionPane miOption { set; get; }

        public List<ConsultaImpuesto> ConsImpuesto { set; get; }

        private List<Impuesto> ResumenIva { set; get; }

        public DataRow RowEmpresa { set; get; }

        private int IdSelectDate { set; get; }

        private string FileRuta { set; get; }


        //private BussinesEmpresa miBussinesEmpresa;

        public FrmConsultaImpuestos()
        {
            InitializeComponent();

            var lst = new List<Criterio>();

            lst.Add(new Criterio
            {
                Id = 1,
                Nombre = "Fecha"
            });
            lst.Add(new Criterio
            {
                Id = 2,
                Nombre = "Periodo"
            });
            cbFecha.DataSource = lst;

            /*this.cbFecha.Items.AddRange(new object[] 
            {
                new Criterio { Id = 1, Nombre = "Fecha"} ,
                new Criterio { Id = 2, Nombre = "Periodo" }
            });*/
            
            //miBussinesEmpresa = new BussinesEmpresa();
        }

        private void FrmConsultaImpuestos_Load(object sender, EventArgs e)
        {
            this.dgvConsultaImpuesto.AutoGenerateColumns = false;
            this.dgvIva.AutoGenerateColumns = false;
            //CargarDatos();
        }


        /*private void CargarDatos()
        {
            var lst = new List<Criterio>();

            lst.Add(new Criterio
            {
                Id = 1,
                Nombre = "Fecha"
            });
            lst.Add(new Criterio
            {
                Id = 2,
                Nombre = "Periodo"
            });
            cbFecha.DataSource = lst;
            
        }*/

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

        public void CargarResumenIva()
        {
            try
            {
                this.ResumenIva = new List<Impuesto>
                {
                    new Impuesto
                    {
                        Tarifa = "0", 
                        BaseGravable = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Base0)),
                        ValorIva = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Iva0)),
                        Total = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Base0) + this.ConsImpuesto.Sum(s => s.Iva0))
                    },
                    new Impuesto
                    {
                        Tarifa = "1E-07", 
                        BaseGravable = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Base1E)),
                        ValorIva = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Iva1E)),
                        Total = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Base1E) + this.ConsImpuesto.Sum(s => s.Iva1E))
                    },
                    new Impuesto
                    {
                        Tarifa = "5", 
                        BaseGravable = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Base5)),
                        Impoconsumo = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.IcoBase5)),
                        ValorIva = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Iva5)),
                        Total = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Base5) + 
                                                this.ConsImpuesto.Sum(s => s.Iva5) + 
                                                this.ConsImpuesto.Sum(s => s.IcoBase5))
                    },
                    new Impuesto
                    {
                        Tarifa = "19", 
                        BaseGravable = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Base19)),
                        Impoconsumo = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.IcoBase19)),
                        ValorIva = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Iva19)),
                        Total = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Base19) + 
                                                this.ConsImpuesto.Sum(s => s.Iva19) +
                                                this.ConsImpuesto.Sum(s => s.IcoBase19))
                    }
                };

                this.dgvIva.DataSource = this.ResumenIva;

                this.txtTotalBaseIva.Text = UseObject.InsertSeparatorMil(this.ResumenIva.Sum(s => s.BaseGravable).ToString());
                this.txtTotalImpoconsumo.Text = UseObject.InsertSeparatorMil(this.ResumenIva.Sum(s => s.Impoconsumo).ToString());
                this.txtTotalIva.Text = UseObject.InsertSeparatorMil(this.ResumenIva.Sum(s => s.ValorIva).ToString());
                this.txtTotalNetoIva.Text = UseObject.InsertSeparatorMil(this.ResumenIva.Sum(s => s.Total).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void CargarTotales()
        {
            try
            {
                this.txtSubTotal.Text = UseObject.InsertSeparatorMil((this.ConsImpuesto.Sum(s => s.Base0) + this.ConsImpuesto.Sum(s => s.Base1E) +
                    this.ConsImpuesto.Sum(s => s.Base5) + this.ConsImpuesto.Sum(s => s.Base19) + this.ConsImpuesto.Sum(s => s.Descuento)).ToString());
                this.txtDescuento.Text = UseObject.InsertSeparatorMil(this.ConsImpuesto.Sum(s => s.Descuento).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil((this.ConsImpuesto.Sum(s => s.Iva5) + this.ConsImpuesto.Sum(s => s.Iva19)).ToString());
                this.txtImpoconsumo.Text = UseObject.InsertSeparatorMil((this.ConsImpuesto.Sum(s => s.IcoBase5) + this.ConsImpuesto.Sum(s => s.IcoBase19)).ToString());
                this.txtIncBolsas.Text = UseObject.InsertSeparatorMil(this.ConsImpuesto.Sum(s => s.IncBolsa).ToString());
                this.txtRetenciones.Text = UseObject.InsertSeparatorMil(this.ConsImpuesto.Sum(s => s.Retencion).ToString());
                this.txtTotal.Text = UseObject.InsertSeparatorMil(this.ConsImpuesto.Sum(s => s.Total).ToString());


                
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnGuardarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvConsultaImpuesto.Rows.Count > 0)
                {
                    this.IdSelectDate = Convert.ToInt32(this.cbFecha.SelectedValue);

                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.Filter = "Excel (*.xls)|*.xlsx";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        this.FileRuta = fichero.FileName;
                        miOption = new OptionPane();
                        miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                        miOption.FrmProgressBar.Closed_ = true;
                        miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                            "Operacion en progreso");
                        miThread = new Thread(SaveExcel);
                        miThread.Start();
                    }
                }



                //var empresa = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
               /* int fila = 1, columna = 1;
                SLDocument sld = new SLDocument();
                sld.SetCellValue(1, 1, RowEmpresa["Nombre"].ToString());
                sld.SetCellValue(2, 1, RowEmpresa["Juridico"].ToString());
                sld.SetCellValue(3, 1, RowEmpresa["Nit"].ToString());
                sld.SetCellValue(4, 1, RowEmpresa["Direccion"].ToString());
                sld.SetCellValue(5, 1, "");
                sld.SetCellValue(6, 1, "INFORME DE VENTAS");
                if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
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
                sld.SaveAs(@"D:\consultaImpuesto.xlsx");*/
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

        private void SaveExcel()
        {
            try
            {
                //var empresa = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
                int fila = 1, columna = 1;
                SLDocument sld = new SLDocument();
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
                sld.SaveAs(this.FileRuta);
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

        
    }
}