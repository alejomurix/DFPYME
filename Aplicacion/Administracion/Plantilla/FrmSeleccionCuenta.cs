using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using Utilities;
using CustomControl;
using DTO.Clases;

namespace Aplicacion.Administracion.Plantilla
{
    public partial class FrmSeleccionCuenta : Form
    {
        private int IdCuenta { set; get; }

        private ErrorProvider miError;

        private bool CuentaMatch;

        private bool Transfer { set; get; }

        private BussinesPuc miBussinesPuc;

        public FrmSeleccionCuenta()
        {
            InitializeComponent();
            this.miError = new ErrorProvider();
            this.CuentaMatch = false;
            this.miBussinesPuc = new BussinesPuc();
        }

        private void FrmSeleccionCuenta_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);

            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Debe"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Haber"
            });
            this.cbNaturaleza.DataSource = lst;
        }

        private void FrmSeleccionCuenta_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (!Validacion.EsVacio(this.txtCuenta, this.miError, "El campo es requerido."))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                        this.txtCuenta, this.miError, "El número que ingreso es incorrecto."))
                    {
                        this.miError.SetError(this.txtCuenta, null);
                        try
                        {
                            var cuenta = miBussinesPuc.Cuenta(this.txtCuenta.Text);
                            if (cuenta.Id.Equals(0))
                            {
                                this.miError.SetError(this.txtCuenta, "La cuenta no existe.");
                                this.CuentaMatch = false;
                            }
                            else
                            {
                                this.miError.SetError(this.txtCuenta, null);
                                this.txtNombre.Text = cuenta.Nombre;
                                this.IdCuenta = cuenta.Id;
                                this.CuentaMatch = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else
                    {
                        this.CuentaMatch = false;
                    }
                }
                else
                {
                    this.CuentaMatch = false;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var frmPuc = new Puc.FrmConsultaPucUtil();
            frmPuc.Extend = true;
            this.Transfer = true;
            frmPuc.ShowDialog();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.CuentaMatch)
            {
                var naturaleza = (Inventario.Producto.Criterio)this.cbNaturaleza.SelectedItem;
                CuentaAuxiliar ctaAux = new CuentaAuxiliar();
                ctaAux.IdCuenta = this.IdCuenta;
                ctaAux.Numero = this.txtCuenta.Text;
                ctaAux.Nombre = this.txtNombre.Text;
                ctaAux.IdNaturaleza = naturaleza.Id;
                ctaAux.Naturaleza = naturaleza.Nombre;
                CompletaEventos.CapturaEvento(new ObjectAbstract
                {
                    Id = 660,
                    Objeto = ctaAux
                });
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (this.Transfer)
                {
                    var obj = (ObjectAbstract)args.MiObjeto;
                    if (obj.Id.Equals(650))
                    {
                        this.txtCuenta.Text = (string)obj.Objeto;
                        this.txtCuenta_KeyPress(this.txtCuenta, new KeyPressEventArgs((char)Keys.Enter));
                    }
                    this.Transfer = false;
                }
            }
            catch { }
        }
    }
}