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

namespace Aplicacion.Administracion.Dian
{
    public partial class frmDian : Form
    {
        private DTO.Clases.Dian dian;

        /// <summary>
        /// Atributos del modelo de negocios
        /// </summary>
        private BussinesDian miBussinesDian;

        private Validacion miValidacion;

        /// <summary>
        /// Objeto de mensajeria de error.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Obtienen o establece el valor de la validacion en el formulario.
        /// </summary>
        private bool numeroresolucion,
                     serieInicio,
                     rangoInicio,
                     serieFin,
                     rangoFin = false;

        /// <summary>
        /// Obtiene o establece  al valor en la validación;
        /// Si comprobación es false vuelvo a validar los datos el el formilario
        /// </summary>
        private bool Comprobacion = false;

        private DataRow rowDian;

        public frmDian()
        {
            InitializeComponent();
            try
            {
                miBussinesDian = new BussinesDian();
                miValidacion = new Validacion();
                miError = new ErrorProvider();

                this.txtNumerosRestantes.Text = AppConfiguracion.ValorSeccion("numero_restantes_alert");
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("bloquear_facturacion")))
                {
                    this.chkBloquearFacturacion.Checked = true;
                }
                else
                {
                    this.chkBloquearFacturacion.Checked = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void frmDian_Load(object sender, EventArgs e)
        {
            //ConsultarRegistroDian();
            CargarContadoCredito();
            ConsultarRegistroDian();
            CargarConfiguracionImpresion();
        }

        private void frmDian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (rta.Equals("1002-105-AJUST"))
                {
                    try
                    {
                        this.miBussinesDian.ActualizarIdDian();
                        OptionPane.MessageInformation("El ajuste se realizó con éxito.");
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            Revalidar();
            if (numeroresolucion && serieInicio && rangoInicio && serieFin && rangoFin)
            {
                try
                {
                    if (!Comprobacion)
                    {
                        CargarDianMemoria();
                        txtNumeroResolucion.Focus();
                        Limpiacampos();
                        OptionPane.MessageInformation("Por favor ingrese de nuevo los datos.");
                        Comprobacion = true;
                    }
                    else
                    {
                        if (ComprobarDatosDian())
                        {
                            miBussinesDian.InsetarDian(dian, true);
                            /*if (((Inventario.Producto.Criterio)tsCbDescto.SelectedItem).Id.Equals(1))
                            {
                                miBussinesDian.InsetarDian(dian, true);
                            }
                            else
                            {
                                miBussinesDian.InsetarDian(dian, false);
                            }*/
                            OptionPane.MessageInformation("El registro se a guardado exitosamente.");
                            Limpiacampos();
                            ConsultarRegistroDian();
                            CargarConfiguracionImpresion();
                            Comprobacion = false;
                        }
                        else
                        {
                            Limpiacampos();
                            dian = null;
                            Comprobacion = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageInformation(ex.Message);
                }
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroResolucion_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNumeroResolucion, miError, "El campo de numero de resolución es requerido"))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtNumeroResolucion, miError, "El campo de numero resolucion tiene formato incorrecto"))
                {
                    numeroresolucion = true;
                }
                else
                    numeroresolucion = false;
            }
            else
                numeroresolucion = false;
        }

        private void txtSerieInicio_Validating(object sender, CancelEventArgs e)
        {
            
            if (String.IsNullOrEmpty(txtSerieInicio.Text))
            {
                txtSerieInicio.Text = "0";
                serieInicio = true;
            }
            else
            {
                serieInicio = true;
                /*if (txtSerieInicio.Text != "0")
                {
                    // if (Validacion.ConFormato(Validacion.TipoValidacion.Serie, txtSerieInicio, miError, "El campo de serie tiene formato incorrecto."))
                    //{
                    // serieInicio = true;   
                    try
                    {
                        Convert.ToInt32(txtSerieInicio.Text);
                        txtSerieInicio.Text += "-";
                        serieInicio = true;
                    }
                    catch
                    {
                        serieInicio = true;
                    }
                    //}
                    //else
                    //  serieInicio = false;
                    //}                
                }
                else
                {
                    serieInicio = true;
                }*/
            }
        }

        private void txtNumeroInicio_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNumeroInicio, miError, "El campo de numero es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtNumeroInicio, miError, "El campo de numero tiene formato incorrecto."))
                {
                    rangoInicio = true;
                }
                else
                    rangoInicio = false;
            }
            else
                rangoInicio = false;
        }

        private void txtSerieFinal_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtSerieFinal.Text))
            {
                txtSerieFinal.Text = "0";
                serieFin = true;
            }
            else
            {
                serieFin = true;
               /* if (txtSerieFinal.Text != "0")
                {
                    // if (Validacion.ConFormato(Validacion.TipoValidacion.Serie, txtSerieFinal, miError, "El campo de serie tiene formato incorrecto."))
                    //{
                    // serieFin = true;
                    try
                    {
                        Convert.ToInt32(txtSerieFinal.Text);
                        txtSerieFinal.Text += "-";
                        serieFin = true;
                    }
                    catch
                    {
                        serieFin = true;
                    }
                    //}
                    //else
                    //  serieFin = false;
                }
                else
                {
                    serieFin = true;
                }*/
            }
        }

        private void txtNumeroFin_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNumeroFin, miError, "el campo de numero es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtNumeroFin, miError, "El campo de numero es requerido."))
                {
                    rangoFin = true;
                }
                else
                    rangoFin = false;
            }
            else
                rangoFin = false;
        }

        /// <summary>
        /// Carga el combo con los criterios para registro de contado o crédito.
        /// </summary>
        private void CargarContadoCredito()
        {
            var lista = new List<Inventario.Producto.Criterio>();
            lista.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "POS"
            });
            lista.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "COMPUTADOR"
            });
            this.cbModalidad.DataSource = lista;
           /* var lista = new List<Inventario.Producto.Criterio>();
            lista.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Contado"
            });
            lista.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Credito"
            });
            tsCbDescto.ComboBox.DataSource = lista;
            tsCbDescto.ComboBox.DisplayMember = "Nombre";
            tsCbDescto.ComboBox.ValueMember = "Id";
            tsCbDesctoConsulta.ComboBox.DataSource = lista;
            tsCbDesctoConsulta.ComboBox.DisplayMember = "Nombre";
            tsCbDesctoConsulta.ComboBox.ValueMember = "Id";*/
        }

        /// <summary>
        /// Valido los campos del formulario.
        /// </summary>
        private void Revalidar()
        {
            txtNumeroFin_Validating(null, null);
            txtNumeroInicio_Validating(null, null);
            txtNumeroResolucion_Validating(null, null);
            txtSerieFinal_Validating(null, null);
            txtSerieInicio_Validating(null, null);
        }

        /// <summary>
        /// Revalido o compruebo que los datos ingresados sean los mismos
        /// </summary>
        private void  CargarDianMemoria()
        {
            try
            {
                dian = new DTO.Clases.Dian();
                dian.NumeroResolucion = Convert.ToInt64(txtNumeroResolucion.Text);
                dian.FechaExpedicion = FechaSinHora(dtpFechaExpedicion.Value);
                dian.SerieInicial = txtSerieInicio.Text;
                dian.RangoInicial = Convert.ToInt64(txtNumeroInicio.Text);
                dian.SerieFinal = txtSerieFinal.Text;
                dian.RangoFinal = Convert.ToInt64(txtNumeroFin.Text);
                dian.TextoInicial = this.txtTextoInicialSave.Text;
                dian.TextoFinal = this.txtTextoFinalSave.Text;
                dian.IdModalidad = Convert.ToInt32(this.cbModalidad.SelectedValue);
            }
            catch
            { }
        }

        /// <summary>
        /// Limpio los campos del formulario.
        /// </summary>
        private void Limpiacampos()
        {
            this.txtNumeroResolucion.Focus();
            this.txtNumeroFin.Text = "";
            this.txtNumeroInicio.Text = "";
            this.txtNumeroResolucion.Text = "";
            this.txtSerieFinal.Text = "";
            this.txtSerieInicio.Text = "";            
        }

        /// <summary>
        /// Compruebo los campos ingresados con los campos en memoria.
        /// </summary>
        /// <returns></returns>
        private bool ComprobarDatosDian()
        {
            if (dian.NumeroResolucion.Equals(Convert.ToInt64(txtNumeroResolucion.Text)) &&
                dian.FechaExpedicion.Equals(FechaSinHora(dtpFechaExpedicion.Value)) &&
                dian.SerieInicial.Equals(txtSerieInicio.Text) &&
                dian.RangoInicial.Equals(Convert.ToInt64(txtNumeroInicio.Text)) &&
                dian.SerieFinal.Equals(txtSerieFinal.Text) &&
                dian.RangoFinal.Equals(Convert.ToInt64(txtNumeroFin.Text)))
            {
                return true;
            }
            else
            {
                OptionPane.MessageInformation("Algunos de los campos no coinciden con los datos.\nIntente el registro nuevamente.");
                return false;
            }

        }

        /// <summary>
        /// Consulta en la base de datos los registros dian.
        /// </summary>
        private void ConsultarRegistroDian()
        {
            try
            {
                dgvDian.AutoGenerateColumns = false;
                dgvDian.DataSource = miBussinesDian.ConsultaDian();
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void ConsultaDianCredito()
        {
            try
            {
                dgvDian.AutoGenerateColumns = false;
                dgvDian.DataSource = miBussinesDian.ConsultaDianCredito();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Obtengo o establezco el valor de la fecha.
        /// </summary>
        /// <param name="fecha">fecha a stablecer el nuevo valor</param>
        /// <returns></returns>
        private DateTime FechaSinHora(DateTime fecha)
        {
            var tem = new DateTime
                (fecha.Year, fecha.Month, fecha.Day, 12, 0, 0);
            return tem;
        }

        private void tsCbDesctoConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  var idContado = ((Inventario.Producto.Criterio)tsCbDesctoConsulta.SelectedItem).Id;
            if (idContado == 1)
            {
                ConsultarRegistroDian();
            }
            else
            {
                ConsultaDianCredito();
            }*/
        }


        //  Configuracion de impresion

        private void tsBtnGuardarConfImpresion_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.rowDian != null)
                {
                    this.miBussinesDian.EditarTextos(this.txtTextoInicial.Text, this.txtTextoFinal.Text);
                    OptionPane.MessageInformation("Los datos se editaron con éxito.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarConfiguracionImpresion()
        {
            try
            {
                var tDian = this.miBussinesDian.ConsultaDian();
                if (tDian.Rows.Count > 0)
                {
                    this.rowDian = tDian.AsEnumerable().Last();

                    this.txtTextoInicialSave.Text = this.rowDian["TxtInicial"].ToString();
                    this.txtTextoFinalSave.Text = this.rowDian["TxtFinal"].ToString();

                    this.txtTextoInicial.Text = this.rowDian["TxtInicial"].ToString();
                    this.txtTextoFinal.Text = this.rowDian["TxtFinal"].ToString();

                    this.lblMuestraCarta.Text = this.rowDian["TxtInicial"].ToString() + this.rowDian["Resolucion"].ToString() + " de " +
                        Convert.ToDateTime(this.rowDian["Fecha"]).ToShortDateString() +
                        " del " + this.rowDian["Desde"].ToString() + " al " + this.rowDian["Hasta"].ToString() + " " + this.rowDian["TxtFinal"].ToString() + ".";

                    this.lblMuestraTirilla_1.Text = this.rowDian["TxtInicial"].ToString() + this.rowDian["Resolucion"].ToString();
                    this.lblMuestraTirilla_2.Text = "de " + Convert.ToDateTime(this.rowDian["Fecha"]).ToShortDateString();
                    this.lblMuestraTirilla_3.Text = this.rowDian["TxtFinal"].ToString() + " del " + this.rowDian["Desde"].ToString() + " al " + this.rowDian["Hasta"].ToString() + ".";
                }

                /*ticket.AddHeaderLine(dianRow["TxtInicial"].ToString() + " : " + dianRow["Resolucion"].ToString());
                ticket.AddHeaderLine("      de : " + Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString());
                ticket.AddHeaderLine(dianRow["TxtFinal"].ToString() + " : " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString());*/

                /*pResDian.Values.Add(dianRow["TxtInicial"].ToString() + " " + dianRow["Resolucion"].ToString() + " de " + 
                    Convert.ToDateTime(dianRow["Fecha"]).ToShortDateString()
            + " del " + dianRow["Desde"].ToString() + " al " + dianRow["Hasta"].ToString() + " " + dianRow["TxtFinal"].ToString() + ".");*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtTextoInicial_KeyUp(object sender, KeyEventArgs e)
        {
            this.ImpresionDian();
        }

        private void txtTextoFinal_KeyUp(object sender, KeyEventArgs e)
        {
            this.ImpresionDian();
        }

        private void ImpresionDian()
        {
            if (this.rowDian != null)
            {
                this.lblMuestraCarta.Text = this.txtTextoInicial.Text + this.rowDian["Resolucion"].ToString() + " de " +
                        Convert.ToDateTime(this.rowDian["Fecha"]).ToShortDateString() +
                        " del " + this.rowDian["Desde"].ToString() + " al " + this.rowDian["Hasta"].ToString() + " " + this.txtTextoFinal.Text + ".";

                this.lblMuestraTirilla_1.Text = this.txtTextoInicial.Text + this.rowDian["Resolucion"].ToString();
                this.lblMuestraTirilla_2.Text = "de " + Convert.ToDateTime(this.rowDian["Fecha"]).ToShortDateString();
                this.lblMuestraTirilla_3.Text = this.txtTextoFinal.Text + " del " + this.rowDian["Desde"].ToString() + " al " + this.rowDian["Hasta"].ToString() + ".";
            }
        }

        private void btnGuardarConfigDian_Click(object sender, EventArgs e)
        {
            try
            {
                AppConfiguracion.SaveConfiguration("numero_restantes_alert", this.txtNumerosRestantes.Text);
                if (this.chkBloquearFacturacion.Checked)
                {
                    AppConfiguracion.SaveConfiguration("bloquear_facturacion", "true");
                }
                else
                {
                    AppConfiguracion.SaveConfiguration("bloquear_facturacion", "false");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

    }
}