using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControl;
using DTO.Clases;
using Utilities;
using BussinesLayer.Clases;

namespace Aplicacion.Compras.Egreso.Edit
{
    public partial class FrmEditarEgreso : Form
    {
        public DTO.Clases.Egreso MiEgreso { set; get; }

        private int CodigoEgreso = 5;

        private BussinesEgreso miBussinesEgreso;

        private Validacion validacion;

        private ErrorProvider miError;

        private bool CodigoMatch = false;

        private bool ConceptoMatch = false;

        private bool ValorMatch = false;

        private bool EfectivoMatch = false;

        private bool ChequeMatch = false;

        private DataTable tabla;

        private int Contador = 0;

        private BindingSource miBindingSource;

        public FrmEditarEgreso()
        {
            InitializeComponent();
            miBussinesEgreso = new BussinesEgreso();
            validacion = new Validacion();
            miError = new ErrorProvider();
            miBindingSource = new BindingSource();
        }

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            dgvEgreso.AutoGenerateColumns = false;
            dgvEgreso.DataSource = miBindingSource;
        }

        private void FrmEgreso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F1))
            {
                SeleccionarEfectivo();
            }
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (!dgvEgreso.RowCount.Equals(0))
            {
                txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
                txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
                if (EfectivoMatch && ChequeMatch)
                {
                    DialogResult rta = MessageBox.Show("¿Está seguro de querer generar el egreso?", "Egreso",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rta.Equals(DialogResult.Yes))
                    {
                        var egreso = new DTO.Clases.Egreso();
                        egreso.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                        egreso.IdCaja = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"));
                        egreso.Numero = lblNumero.Text;
                        egreso.Fecha = DateTime.Now;
                        egreso.Total = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtTotal.Text));
                        egreso.Estado = true;
                        egreso.Pagos = Pagos();
                        egreso.Cuentas = Cuentas();
                        try
                        {
                            miBussinesEgreso.IngresarEgreso(egreso);
                            OptionPane.MessageInformation("Los Datos del Egreso se almacenarón correctamente.");
                            var printEgreso = new FrmPrintComprobante();
                            printEgreso.MdiParent = this.MdiParent;
                            printEgreso.Numero = lblNumero.Text;
                            printEgreso.Fecha = DateTime.Now;
                            printEgreso.Cuentas = tabla;
                            printEgreso.Cheque = UseObject.RemoveSeparatorMil(txtCheque.Text).ToString();
                            printEgreso.Efectivo = UseObject.RemoveSeparatorMil(txtEfectivo.Text).ToString();
                            printEgreso.Show();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe cargar al menos un concepto con codigo al Egreso.");
            }
        }


        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtConcepto.Focus();
            }
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCodigo, miError, "El campo Código es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtCodigo, miError,
                    "El Código que ingreso es invalido."))
                {
                    if (ValidarCuenta(Convert.ToInt32(txtCodigo.Text), CodigoEgreso))
                    {
                        CodigoMatch = true;
                        miError.SetError(txtCodigo, null);
                    }
                    else
                    {
                        CodigoMatch = false;
                        miError.SetError
                            (txtCodigo, "El Código de cuenta que ingreso no pertenece a la categoría Gastos.");
                    }
                }
                else
                {
                    CodigoMatch = false;
                }
            }
            else
            {
                CodigoMatch = false;
            }
        }

        private void txtConcepto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtValor.Focus();
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtConcepto, miError, "El campo Concepto es requerido."))
            {
                ConceptoMatch = true;
            }
            else
            {
                ConceptoMatch = false;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnAgregar.Focus();
            }
        }

        private void txtValor_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValor, miError, "El campo Valor es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtValor, miError,
                    "El Valor que ingreso es invalido."))
                {
                    ValorMatch = true;
                }
                else
                {
                    ValorMatch = false;
                }
            }
            else
            {
                ValorMatch = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (CodigoMatch && ConceptoMatch && ValorMatch)
            {
                Contador++;
                var row = tabla.NewRow();
                row["Id"] = Contador;
                row["Codigo"] = Convert.ToInt32(txtCodigo.Text);
                row["Concepto"] = txtConcepto.Text;
                row["Valor"] = Convert.ToInt32(txtValor.Text);
                tabla.Rows.Add(row);
                RecargarGridView();
                CalcularTotal();
                txtCodigo.Focus();
                txtCodigo.Text = "";
                txtConcepto.Text = "";
                txtValor.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEgreso.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro(a) de retirar el registro?", "Egreso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var id = (int)dgvEgreso.CurrentRow.Cells["Id"].Value;
                    var row = (from data in tabla.AsEnumerable()
                               where data.Field<int>("Id") == id
                               select data).Single();
                    tabla.Rows.Remove(row);
                    if (tabla.Rows.Count != 0)
                    {
                        RecargarGridView();
                    }
                    else
                    {
                        this.dgvEgreso.Rows.RemoveAt(
                            this.dgvEgreso.CurrentCell.RowIndex);
                    }
                    CalcularTotal();
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay registro para retirar.");
            }
        }



        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCheque.Focus();
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                txtEfectivo.Text = txtEfectivo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtEfectivo.Text))
                {
                    txtEfectivo.Text = UseObject.InsertSeparatorMil(txtEfectivo.Text);
                    EfectivoMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor del Efectivo es inválido.");
                    EfectivoMatch = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                EfectivoMatch = true;
            }
        }

        private void txtCheque_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCheque.Text))
            {
                txtCheque.Text = txtCheque.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtCheque.Text))
                {
                    txtCheque.Text = UseObject.InsertSeparatorMil(txtCheque.Text);
                    ChequeMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor del Cheque es inválido.");
                    ChequeMatch = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                ChequeMatch = true;
            }
        }

        private void CargarUtilidades()
        {
            /*lblFecha.Text = DateTime.Today.ToLongDateString();
            lblNumero.Text = AppConfiguracion.ValorSeccion("const-e") +
                             AppConfiguracion.ValorSeccion("numero-e");*/
            tabla = new DataTable();
            tabla.TableName = "CuentaPuc";
            tabla.Columns.Add(new DataColumn("Id", typeof(int)));
            tabla.Columns.Add(new DataColumn("Codigo", typeof(int)));
            tabla.Columns.Add(new DataColumn("Concepto", typeof(string)));
            tabla.Columns.Add(new DataColumn("Valor", typeof(int)));

            lblFecha.Text = MiEgreso.Fecha.ToLongDateString();
            lblNumero.Text = MiEgreso.Numero;
            foreach (var cuenta in MiEgreso.Cuentas)
            {
                Contador++;
                var row = tabla.NewRow();
                row["Id"] = Contador;
                /*row["Codigo"] = cuenta.Codigo;
                row["Concepto"] = cuenta.Descripcion;
                row["Valor"] = cuenta.Valor;*/
                tabla.Rows.Add(row);
            }
            RecargarGridView();
            CalcularTotal();
            txtEfectivo.Text = UseObject.InsertSeparatorMil(
                MiEgreso.Pagos.Single(p => p.IdFormaPago == 1).Valor.ToString());
            txtCheque.Text = UseObject.InsertSeparatorMil(
                MiEgreso.Pagos.Single(p => p.IdFormaPago == 2).Valor.ToString());
        }

        private bool ValidarCuenta(int subCuenta, int cuenta)
        {
            try
            {
                return miBussinesEgreso.ValidarCuenta(subCuenta, cuenta);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private void RecargarGridView()
        {
            IEnumerable<DataRow> query = from datos in tabla.AsEnumerable()
                                         orderby datos.Field<int>("Id") descending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }

        private void CalcularTotal()
        {
            txtTotal.Text = UseObject.InsertSeparatorMil(
                (tabla.AsEnumerable().Sum(s => s.Field<int>("Valor"))).ToString());
        }

        private void SeleccionarEfectivo()
        {
            txtCodigo.Text = "51";
            txtConcepto.Text = "a";
            txtValor.Text = "0";
            txtEfectivo.Focus();
            txtEfectivo.SelectAll();
            txtCodigo.Text = "";
            txtConcepto.Text = "";
            txtValor.Text = "";
        }

        private List<FormaPago> Pagos()
        {
            var lst = new List<FormaPago>();
            if (!txtEfectivo.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 1,
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtEfectivo.Text))
                });
            }
            if (!txtCheque.Text.Equals("0"))
            {
                lst.Add(new FormaPago
                {
                    IdFormaPago = 2,
                    Valor = Convert.ToInt32(UseObject.RemoveSeparatorMil(txtCheque.Text))
                });
            }
            return lst;
        }

        private List<SubCuentaPuc> Cuentas()
        {
            var lst = new List<SubCuentaPuc>();
            foreach (DataRow row in tabla.Rows)
            {
                /*lst.Add(new SubCuentaPuc
                {
                    Codigo = Convert.ToInt32(row["Codigo"]),
                    Descripcion = row["Concepto"].ToString(),
                    Valor = Convert.ToInt32(row["Valor"])
                });*/
            }
            return lst;
        }




        /*
        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCheque.Focus();
            }
        }

        private void txtEfectivo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEfectivo.Text))
            {
                txtEfectivo.Text = txtEfectivo.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtEfectivo.Text))
                {
                    txtEfectivo.Text = UseObject.InsertSeparatorMil(txtEfectivo.Text);
                    EfectivoMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor del Efectivo es inválido.");
                    EfectivoMatch = false;
                }
            }
            else
            {
                txtEfectivo.Text = "0";
                EfectivoMatch = true;
            }
        }

        private void txtCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTarjeta.Focus();
            }
        }

        private void txtCheque_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCheque.Text))
            {
                txtCheque.Text = txtCheque.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtCheque.Text))
                {
                    txtCheque.Text = UseObject.InsertSeparatorMil(txtCheque.Text);
                    ChequeMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor del Cheque es inválido.");
                    ChequeMatch = false;
                }
            }
            else
            {
                txtCheque.Text = "0";
                ChequeMatch = true;
            }
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtTransaccion.Focus();
            }
        }

        private void txtTarjeta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTarjeta.Text))
            {
                txtTarjeta.Text = txtTarjeta.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtTarjeta.Text))
                {
                    txtTarjeta.Text = UseObject.InsertSeparatorMil(txtTarjeta.Text);
                    TarjetaMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor de la Tarjeta es inválido.");
                    TarjetaMatch = false;
                }
            }
            else
            {
                txtTarjeta.Text = "0";
                TarjetaMatch = true;
            }
        }

        private void txtTransaccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.FrmEgreso_KeyDown(this, new KeyEventArgs(Keys.F6));
            }
        }

        private void txtTransaccion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtTransaccion.Text))
            {
                txtTransaccion.Text = txtTransaccion.Text.Replace(".", "");
                if (validacion.ValidarNumeroInt(txtTransaccion.Text))
                {
                    txtTransaccion.Text = UseObject.InsertSeparatorMil(txtTransaccion.Text);
                    TransacionMatch = true;
                }
                else
                {
                    OptionPane.MessageError("El valor de la Transacción es inválido.");
                    TransacionMatch = false;
                }
            }
            else
            {
                txtTransaccion.Text = "0";
                TransacionMatch = true;
            }
        }

        /// <summary>
        /// Carga los datos necesarios para el uso del formulario.
        /// </summary>
        private void CargarUtilidades()
        {
            lblNumero.Text = "Egreso No " + AppConfiguracion.ValorSeccion("const-e") +
                                            AppConfiguracion.ValorSeccion("numero-e");
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Caja Registradora"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Caja General"
            });
            cbRegistro.DataSource = lst;
        }

        /// <summary>
        /// Valida de nuevo los campos de texto.
        /// </summary>
        private void Validar()
        {
            txtEfectivo_Validating(this.txtEfectivo, new CancelEventArgs(false));
            txtCheque_Validating(this.txtCheque, new CancelEventArgs(false));
            txtTarjeta_Validating(this.txtTarjeta, new CancelEventArgs(false));
            txtTransaccion_Validating(this.txtTransaccion, new CancelEventArgs(false));
        }

        private List<DTO.Clases.FormaPago> FormasDePago()
        {
            var Formas = new List<DTO.Clases.FormaPago>();
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 1,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtEfectivo.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 2,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtCheque.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 3,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtTarjeta.Text))
            });
            Formas.Add(new DTO.Clases.FormaPago
            {
                IdFormaPago = 4,
                Valor = Convert.ToInt32
                (UseObject.RemoveSeparatorMil(txtTransaccion.Text))
            });
            txtTotal.Text = 
                UseObject.InsertSeparatorMil(Formas.Sum(f => f.Valor).ToString());
            return Formas;
        }

        private void LimpiarForm()
        {
            lblNumero.Text = "Egreso No" + AppConfiguracion.ValorSeccion("const-e") +
                                           AppConfiguracion.ValorSeccion("numero-e");
            txtConcepto.Text = "";
            txtEfectivo.Text = "0";
            txtCheque.Text = "0";
            txtTarjeta.Text = "0";
            txtTransaccion.Text = "0";
            txtTotal.Text = "0";
            txtConcepto.Focus();
        }
        */
    }
}