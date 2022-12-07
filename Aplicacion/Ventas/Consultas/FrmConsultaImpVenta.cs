using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using CustomControl;
using System.Threading;
using BussinesLayer.Clases;
using Utilities;

namespace Aplicacion.Ventas.Consultas
{
    public partial class FrmConsultaImpVenta : FormulariosSistema.FrmConsultaImpuestos
    {
        private bool Transfer { set; get; }

        private string Tercero { set; get; }

        private int IdUsuario { set; get; }


        private BussinesEmpresa miBussinesEmpresa;

        private BussinesConsultaVentas miBussinesConsultaVentas;

        public FrmConsultaImpVenta()
        {
            InitializeComponent();
            this.dgvIvaCosto.AutoGenerateColumns = false;

            this.Transfer = false;
            this.Tercero = "";
            this.IdUsuario = 0;

            var lst_ = new List<Criterio>();

            lst_.Add(new Criterio
            {
                Id = 0,
                Nombre = "Todas"
            });
            lst_.Add(new Criterio
            {
                Id = 1,
                Nombre = "Contado"
            });
            lst_.Add(new Criterio
            {
                Id = 2,
                Nombre = "Crédito"
            });
            this.cbCriterio.DataSource = lst_;

           /* this.cbCriterio.Items.AddRange(new object[] 
            {
                new Criterio { Id = 0, Nombre = "Todas"} ,
                new Criterio { Id = 1, Nombre = "Contado"} ,
                new Criterio { Id = 2, Nombre = "Crédito" }
            });*/



            /*var lst_ = new List<Criterio>();

            lst_.Add(new Criterio
            {
                Id = 0,
                Nombre = "Todas"
            });
            lst_.Add(new Criterio
            {
                Id = 1,
                Nombre = "Contado"
            });
            lst_.Add(new Criterio
            {
                Id = 2,
                Nombre = "Crédito"
            });
            this.cbCriterio.DataSource = lst_; */

            lst_ = new List<Criterio>();

            lst_.Add(new Criterio
            {
                Id = 1,
                Nombre = ""
            });
            lst_.Add(new Criterio
            {
                Id = 2,
                Nombre = "Cliente"
            });
            lst_.Add(new Criterio
            {
                Id = 3,
                Nombre = "Usuario"
            });
            this.cbTercero.DataSource = lst_;


            this.gbResumenIva.Text = "IVA en ventas";

            this.miBussinesEmpresa = new BussinesEmpresa();
            this.miBussinesConsultaVentas = new BussinesConsultaVentas();

            this.RowEmpresa = miBussinesEmpresa.PrintEmpresa().Tables[0].AsEnumerable().First();
        }

        private void FrmConsultaImpVenta_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
            /*
            var lst_ = new List<Criterio>();

            lst_.Add(new Criterio
            {
                Id = 0,
                Nombre = "Todas"
            });
            lst_.Add(new Criterio
            {
                Id = 1,
                Nombre = "Contado"
            });
            lst_.Add(new Criterio
            {
                Id = 2,
                Nombre = "Crédito"
            });
            /*lst.Add(new Criterio
            {
                Id = 3,
                Nombre = "Anulada"
            });
            this.cbCriterio.DataSource = lst_;


            lst_ = new List<Criterio>();

            lst_.Add(new Criterio
            {
                Id = 1,
                Nombre = ""
            });
            lst_.Add(new Criterio
            {
                Id = 2,
                Nombre = "Cliente"
            });
            lst_.Add(new Criterio
            {
                Id = 3,
                Nombre = "Usuario"
            });
            this.cbTercero.DataSource = lst_;*/
        }

        private void cbTercero_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtTercero.Text = "";
            if (Convert.ToInt32(this.cbTercero.SelectedValue).Equals(2) || Convert.ToInt32(this.cbTercero.SelectedValue).Equals(3))
            {
                this.txtTercero.Enabled = true;
                this.btnBuscarTercero.Enabled = true;
            }
            else
            {
                this.txtTercero.Enabled = false;
                this.btnBuscarTercero.Enabled = false;
            }
        }


        private void btnBuscarTercero_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbTercero.SelectedValue).Equals(2))
            {
                var frmCliente = new Cliente.frmCliente();
                frmCliente.FacturaVenta = true;
                frmCliente.tcClientes.SelectedIndex = 1;
                this.Transfer = true;
                frmCliente.ShowDialog();
            }
            else
            {
                if (Convert.ToInt32(cbTercero.SelectedValue).Equals(3))
                {
                    var frmUsuarios = new Administracion.Usuario.FrmUsuarios();
                    frmUsuarios.ShowDialog();
                }
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.CriterioEstado = Convert.ToInt32(this.cbCriterio.SelectedValue);
            this.CriterioTercero = Convert.ToInt32(this.cbTercero.SelectedValue);
            this.CriterioFecha = Convert.ToInt32(this.cbFecha.SelectedValue);

            this.Fecha1 = this.dtpFecha1.Value;
            this.Fecha2 = this.dtpFecha2.Value;

            if (!String.IsNullOrEmpty(this.txtTercero.Text))
            {
                if (this.CriterioTercero.Equals(2))  // cliente
                {
                    this.Tercero = this.txtTercero.Text;
                }
                else
                {
                    if (this.CriterioTercero.Equals(3))  // usuario
                    {
                        this.IdUsuario = Convert.ToInt32(this.txtTercero.Text);
                    }
                }
            }

            this.miOption = new OptionPane();
            this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
            this.miOption.FrmProgressBar.Closed_ = true;
            this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                "Operacion en progreso");
            this.Enabled = false;
            this.miThread = new Thread(Consultar);
            this.miThread.Start();
        }

        private void Consultar()
        {
            try
            {
                if (this.CriterioEstado.Equals(0)) // todas
                {
                    if (this.CriterioTercero.Equals(1))
                    {
                        if (this.CriterioFecha.Equals(1))  //  fecha
                        {
                            this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVenta(this.Fecha1);
                        }
                        else    //  periodo
                        {
                            this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVenta(this.Fecha1, this.Fecha2);
                        }
                    }
                    else
                    {
                        if (this.CriterioTercero.Equals(2))  // cliente
                        {
                            if (this.CriterioFecha.Equals(1))  //  fecha
                            {
                                this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVenta(this.Tercero, this.Fecha1);
                            }
                            else
                            {
                                this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVenta(this.Tercero, this.Fecha1, this.Fecha2);
                            }
                        }
                        else                                    // usuario
                        {
                            if (this.CriterioFecha.Equals(1))  //  fecha
                            {
                                this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVentaUsuario(this.IdUsuario, this.Fecha1);
                            }
                            else
                            {
                                this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVentaUsuario(this.IdUsuario, this.Fecha1, this.Fecha2);
                            }
                        }
                    }
                }
                else   // Contado o Crédito
                {
                    if (this.CriterioTercero.Equals(1))
                    {
                        if (this.CriterioFecha.Equals(1))  //  fecha
                        {
                            this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVenta(this.CriterioEstado, this.Fecha1);
                        }
                        else    //  periodo
                        {
                            this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVenta(this.CriterioEstado, this.Fecha1, this.Fecha2);
                        }
                    }
                    else
                    {
                        if (this.CriterioTercero.Equals(2))  // cliente
                        {
                            if (this.CriterioFecha.Equals(1))  //  fecha
                            {
                                this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVenta(this.CriterioEstado, this.Tercero, this.Fecha1);
                            }
                            else
                            {
                                this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVenta(this.CriterioEstado, this.Tercero, this.Fecha1, this.Fecha2);
                            }
                        }
                        else                                   // usuario
                        {
                            if (this.CriterioFecha.Equals(1))  //  fecha
                            {
                                this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVentaUsuario(this.CriterioEstado, this.IdUsuario, this.Fecha1);
                            }
                            else
                            {
                                this.ConsImpuesto = this.miBussinesConsultaVentas.ConsultaImpVentaUsuario(this.CriterioEstado, this.IdUsuario, this.Fecha1, this.Fecha2);
                            }
                        }
                    }
                }

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
                this.dgvConsultaImpuesto.DataSource = this.ConsImpuesto;
                this.CargarResumenIvaCosto();
                this.CargarResumenIva();
                this.CargarTotales();

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


        public void CargarResumenIvaCosto()
        {
            try
            {
                List<Impuesto> ResumenIva = new List<Impuesto>
                {
                    new Impuesto
                    {
                        Tarifa = "0", 
                        BaseGravable = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo0)),
                        ValorIva = 0, 
                        Total = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo0)) 
                    },
                    new Impuesto
                    {
                        Tarifa = "1E-07", 
                        BaseGravable = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo1E)),
                        ValorIva = 0,
                        Total = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo1E))
                    },
                    new Impuesto
                    {
                        Tarifa = "5", 
                        BaseGravable = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo5))
                        //Total = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo5)),
                        //BaseGravable = Convert.ToInt32( this.ConsImpuesto.Sum(s => s.Costo5) / 1.05),
                        //ValorIva = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo5)) - Convert.ToInt32( this.ConsImpuesto.Sum(s => s.Costo5) / 1.05)
                    },
                    new Impuesto
                    {
                        Tarifa = "19", 
                        BaseGravable = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo19))
                        //Total = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo19)),
                        //BaseGravable = Convert.ToInt32( this.ConsImpuesto.Sum(s => s.Costo19) / 1.19),
                        //ValorIva = Convert.ToInt32(this.ConsImpuesto.Sum(s => s.Costo19)) - Convert.ToInt32( this.ConsImpuesto.Sum(s => s.Costo19) / 1.19)
                    }
                };

                this.dgvIvaCosto.DataSource = ResumenIva;

                this.txtTotalBaseIvaCosto.Text = UseObject.InsertSeparatorMil(ResumenIva.Sum(s => s.BaseGravable).ToString());
                this.txtTotalIvaCosto.Text = UseObject.InsertSeparatorMil(ResumenIva.Sum(s => s.ValorIva).ToString());
                this.txtTotalNetoIvaCosto.Text = UseObject.InsertSeparatorMil(ResumenIva.Sum(s => s.Total).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (this.Transfer)
                {
                    var cliente = (string)args.MiObjeto;
                    this.Tercero = this.txtTercero.Text = cliente;
                    this.Transfer = false;
                }
            }
            catch { }

            try
            {
                ObjectAbstract obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(822114433))
                {
                    var usuario_ = (DTO.Clases.Usuario)obj.Objeto;
                    this.IdUsuario = usuario_.Id;
                    this.txtTercero.Text = usuario_.Nombres;
                }
            }
            catch { }
        }

        
    }
}