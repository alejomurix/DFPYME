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
using DTO.Clases;

namespace Aplicacion.Administracion.Puc
{
    public partial class FrmRelacionCuentas : Form
    {
        private bool Edicion { set; get; }

        private int IdCtaInventario { set; get; }

        private int IdCtaVentaCredito { set; get; }

        private int IdCtaVentaEfectivo { set; get; }

        private int IdCtaVentaTransaccion { set; get; }

        private int IdCtaVentaCheque { set; get; }

        private List<SubCuentaPuc> Cuentas { set; get; }

        private ErrorProvider miError;

        private bool CtaInventarioMatch;

        private bool CtaVentaCreditoMatch;

        private bool CtaVentaEfectivoMatch;

        private bool CtaVentaTransaccionMatch;

        private bool CtaVentaChequeMatch;

        private BussinesPuc miBussinesPuc;

        public FrmRelacionCuentas()
        {
            InitializeComponent();
            this.Cuentas = new List<SubCuentaPuc>();
            this.Edicion = false;
            this.miError = new ErrorProvider();
            this.CtaInventarioMatch = false;
            this.CtaVentaCreditoMatch = false;
            this.CtaVentaEfectivoMatch = false;
            this.CtaVentaTransaccionMatch = false;
            this.CtaVentaChequeMatch = false;
            miBussinesPuc = new BussinesPuc();
        }

        private void FrmRelacionCuentas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CompletaEventos.Completaeb += new CompletaEventos.CompletaAccioneb(CompletaEventos_Completaeb);
        }

        private void FrmRelacionCuentas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtCtaInventario_Validating(this.txtCtaInventario, new CancelEventArgs(false));
                this.txtCtaVentaCredito_Validating(this.txtCtaVentaCredito, new CancelEventArgs(false));
                this.txtCtaVentaEfectivo_Validating(this.txtCtaVentaEfectivo, new CancelEventArgs(false));
                this.txtCtaVentaTransaccion_Validating(this.txtCtaVentaTransaccion, new CancelEventArgs(false));
                this.txtCtaVentaCheque_Validating(this.txtCtaVentaCheque, new CancelEventArgs(false));

                if (this.CtaInventarioMatch && this.CtaVentaCreditoMatch &&
                    this.CtaVentaEfectivoMatch && this.CtaVentaTransaccionMatch && this.CtaVentaChequeMatch)
                {
                    if (!this.Edicion)
                    {
                        miBussinesPuc.IngresarRelacion(new SubCuentaPuc
                        {
                            Id = 1,
                            IdCuenta = this.IdCtaInventario,
                            Concepto = "Inventario de productos"
                        });

                        miBussinesPuc.IngresarRelacion(new SubCuentaPuc
                        {
                            Id = 2,
                            IdCuenta = this.IdCtaVentaCredito,
                            Concepto = "Ventas a crédito"
                        });

                        miBussinesPuc.IngresarRelacion(new SubCuentaPuc
                        {
                            Id = 3,
                            IdCuenta = this.IdCtaVentaEfectivo,
                            Concepto = "Ventas en efectivo"
                        });

                        miBussinesPuc.IngresarRelacion(new SubCuentaPuc
                        {
                            Id = 4,
                            IdCuenta = this.IdCtaVentaTransaccion,
                            Concepto = "Ventas en transacción"
                        });

                        miBussinesPuc.IngresarRelacion(new SubCuentaPuc
                        {
                            Id = 5,
                            IdCuenta = this.IdCtaVentaCheque,
                            Concepto = "Ventas con cheque"
                        });

                        OptionPane.MessageInformation("Los datos se almacenarón con exito.");
                    }
                    else
                    {
                        miBussinesPuc.EditarRelacion(new SubCuentaPuc
                        {
                            Id = 1,
                            IdCuenta = this.IdCtaInventario,
                            Concepto = "Inventario de productos"
                        });

                        miBussinesPuc.EditarRelacion(new SubCuentaPuc
                        {
                            Id = 2,
                            IdCuenta = this.IdCtaVentaCredito,
                            Concepto = "Ventas a crédito"
                        });

                        miBussinesPuc.EditarRelacion(new SubCuentaPuc
                        {
                            Id = 3,
                            IdCuenta = this.IdCtaVentaEfectivo,
                            Concepto = "Ventas en efectivo"
                        });

                        miBussinesPuc.EditarRelacion(new SubCuentaPuc
                        {
                            Id = 4,
                            IdCuenta = this.IdCtaVentaTransaccion,
                            Concepto = "Ventas en transacción"
                        });

                        miBussinesPuc.EditarRelacion(new SubCuentaPuc
                        {
                            Id = 5,
                            IdCuenta = this.IdCtaVentaCheque,
                            Concepto = "Ventas con cheque"
                        });

                        OptionPane.MessageInformation("Los datos se editarón con exito.");
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtCtaInventario_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtCtaInventario, this.miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                    this.txtCtaInventario, this.miError, "El número que ingreso es incorrecto."))
                {
                    this.miError.SetError(this.txtCtaInventario, null);
                    try
                    {
                        var cuenta = miBussinesPuc.Cuenta(this.txtCtaInventario.Text);
                        if (cuenta.Id.Equals(0))
                        {
                            this.miError.SetError(this.txtCtaInventario, "La cuenta no existe.");
                            this.CtaInventarioMatch = false;
                        }
                        else
                        {
                            this.miError.SetError(this.txtCtaInventario, null);
                            this.txtNCtaInventario.Text = cuenta.Nombre;
                            this.IdCtaInventario = cuenta.Id;
                            this.CtaInventarioMatch = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    this.CtaInventarioMatch = false;
                }
            }
            else
            {
                this.CtaInventarioMatch = false;
            }
        }

        private void txtCtaInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCtaVentaCredito.Focus();
            }
        }

        private void btnPucInventario_Click(object sender, EventArgs e)
        {
            var frmPuc = new FrmPuc();
            frmPuc.Extend = true;
            frmPuc.tcPuc.SelectTab(1);
            frmPuc.ShowDialog();
        }

        private void txtCtaVentaCredito_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtCtaVentaCredito, this.miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                    this.txtCtaVentaCredito, this.miError, "El número que ingreso es incorrecto."))
                {
                    try
                    {
                        var cuenta = miBussinesPuc.Cuenta(this.txtCtaVentaCredito.Text);
                        if (cuenta.Id.Equals(0))
                        {
                            this.miError.SetError(this.txtCtaVentaCredito, "La cuenta no existe.");
                            this.CtaVentaCreditoMatch = false;
                        }
                        else
                        {
                            this.miError.SetError(this.txtCtaVentaCredito, null);
                            this.txtNCtaVentaCredito.Text = cuenta.Nombre;
                            this.IdCtaVentaCredito = cuenta.Id;
                            this.CtaVentaCreditoMatch = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    this.CtaVentaCreditoMatch = false;
                }
            }
            else
            {
                this.CtaVentaCreditoMatch = false;
            }
        }

        private void txtCtaVentaCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCtaVentaEfectivo.Focus();
            }
        }

        private void txtCtaVentaEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtCtaVentaEfectivo, this.miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                    this.txtCtaVentaEfectivo, this.miError, "El número que ingreso es incorrecto."))
                {
                    try
                    {
                        var cuenta = miBussinesPuc.Cuenta(this.txtCtaVentaEfectivo.Text);
                        if (cuenta.Id.Equals(0))
                        {
                            this.miError.SetError(this.txtCtaVentaEfectivo, "La cuenta no existe.");
                            this.CtaVentaEfectivoMatch = false;
                        }
                        else
                        {
                            this.miError.SetError(this.txtCtaVentaEfectivo, null);
                            this.txtNCtaVentaEfectivo.Text = cuenta.Nombre;
                            this.IdCtaVentaEfectivo = cuenta.Id;
                            this.CtaVentaEfectivoMatch = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    this.CtaVentaEfectivoMatch = false;
                }
            }
            else
            {
                this.CtaVentaEfectivoMatch = false;
            }
        }

        private void txtCtaVentaEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCtaVentaTransaccion.Focus();
            }
        }

        private void txtCtaVentaTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtCtaVentaTransaccion, this.miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                    this.txtCtaVentaTransaccion, this.miError, "El número que ingreso es incorrecto."))
                {
                    try
                    {
                        var cuenta = miBussinesPuc.Cuenta(this.txtCtaVentaTransaccion.Text);
                        if (cuenta.Id.Equals(0))
                        {
                            this.miError.SetError(this.txtCtaVentaTransaccion, "La cuenta no existe.");
                            this.CtaVentaTransaccionMatch = false;
                        }
                        else
                        {
                            this.miError.SetError(this.txtCtaVentaTransaccion, null);
                            this.txtNCtaVentaTransaccion.Text = cuenta.Nombre;
                            this.IdCtaVentaTransaccion = cuenta.Id;
                            this.CtaVentaTransaccionMatch = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    this.CtaVentaTransaccionMatch = false;
                }
            }
            else
            {
                this.CtaVentaTransaccionMatch = false;
            }
        }

        private void txtCtaVentaTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCtaVentaCheque.Focus();
            }
        }

        private void txtCtaVentaCheque_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtCtaVentaCheque, this.miError, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                    this.txtCtaVentaCheque, this.miError, "El número que ingreso es incorrecto."))
                {
                    try
                    {
                        var cuenta = miBussinesPuc.Cuenta(this.txtCtaVentaCheque.Text);
                        if (cuenta.Id.Equals(0))
                        {
                            this.miError.SetError(this.txtCtaVentaCheque, "La cuenta no existe.");
                            this.CtaVentaChequeMatch = false;
                        }
                        else
                        {
                            this.miError.SetError(this.txtCtaVentaCheque, null);
                            this.txtNCtaVentaCheque.Text = cuenta.Nombre;
                            this.IdCtaVentaCheque = cuenta.Id;
                            this.CtaVentaChequeMatch = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    this.CtaVentaChequeMatch = false;
                }
            }
            else
            {
                this.CtaVentaChequeMatch = false;
            }
        }

        private void txtCtaVentaCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.btnGuardar_Click(this.btnGuardar, new EventArgs());
            }
        }

        private void CargarDatos()
        {
            try
            {
                if (miBussinesPuc.GetRowsRelacion() > 0) // Existen registros.
                {
                    var tRelaciones = miBussinesPuc.Relaciones();

                    var cuenta = Cuenta(1, tRelaciones);
                    this.txtCtaInventario.Text = cuenta.Numero;
                    this.txtNCtaInventario.Text = cuenta.Nombre;

                    cuenta = Cuenta(2, tRelaciones);
                    this.txtCtaVentaCredito.Text = cuenta.Numero;
                    this.txtNCtaVentaCredito.Text = cuenta.Nombre;

                    cuenta = Cuenta(3, tRelaciones);
                    this.txtCtaVentaEfectivo.Text = cuenta.Numero;
                    this.txtNCtaVentaEfectivo.Text = cuenta.Nombre;

                    cuenta = Cuenta(4, tRelaciones);
                    this.txtCtaVentaTransaccion.Text = cuenta.Numero;
                    this.txtNCtaVentaTransaccion.Text = cuenta.Nombre;

                    cuenta = Cuenta(5, tRelaciones);
                    this.txtCtaVentaCheque.Text = cuenta.Numero;
                    this.txtNCtaVentaCheque.Text = cuenta.Nombre;

                    this.Edicion = true;
                }
                else  // No existen registros.
                {
                    this.CtaInventarioMatch = true;
                    this.CtaVentaCreditoMatch = true;
                    this.CtaVentaEfectivoMatch = true;
                    this.CtaVentaTransaccionMatch = true;
                    this.CtaVentaChequeMatch = false;

                    this.Edicion = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private SubCuentaPuc Cuenta(int id, DataTable tRelacion)
        {
            var cuenta = new SubCuentaPuc();
            var query = (from data in tRelacion.AsEnumerable()
                         where data.Field<int>("idrelacion").Equals(id)
                         select data).First();

            cuenta.Id = query.Field<int>("idrelacion");
            cuenta.Concepto = query.Field<string>("concepto");
            cuenta.IdCuenta = query.Field<int>("idcuenta");
            cuenta.Numero = query.Field<string>("numero");
            cuenta.Nombre = query.Field<string>("nombre");
            return cuenta;
        }

        void CompletaEventos_Completaeb(CompletaArgumentosDeEventoeb args)
        {
            try
            {
                var cuenta = (SubCuentaPuc)args.MiBodegaeb;
                this.txtCtaInventario.Text = cuenta.Numero;
                this.txtCtaInventario_KeyPress(this.txtCtaInventario, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }
    }
}