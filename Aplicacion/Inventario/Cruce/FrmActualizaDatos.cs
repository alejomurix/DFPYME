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

namespace Aplicacion.Inventario.Cruce
{
    public partial class FrmActualizaDatos : Form
    {
        BussinesInventario miBussinesInventario;

        private ErrorProvider miError;

        public FrmActualizaDatos()
        {
            InitializeComponent();
            miBussinesInventario = new BussinesInventario();
            miError = new ErrorProvider();
        }

        private void FrmActualizaDatos_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNumeroFactura.Text))
            {
                miError.SetError(txtNumeroFactura, null);
                try
                {
                    var miBussinesFactura = new BussinesFacturaVenta();
                    var tFactura = miBussinesFactura.ConsultaNumero(txtNumeroFactura.Text);
                    if (tFactura.Rows.Count != 0)
                    {
                        var numero = txtNumeroFactura.Text;
                        var stop = false;
                        while (!stop)
                        {
                            tFactura = miBussinesFactura.ConsultaNumero(numero);
                            if (tFactura.Rows.Count != 0)
                            {
                                var tProductos = miBussinesFactura.ProductoFacturaVenta(numero, true);
                                foreach (DataRow row in tProductos.Rows)
                                {
                                    var inventario = new DTO.Clases.Inventario
                                    {
                                        CodigoProducto = row["Codigo"].ToString(),
                                        IdMedida = Convert.ToInt32(row["IdMedida"]),
                                        IdColor = Convert.ToInt32(row["IdColor"]),
                                        Cantidad = Convert.ToDouble(row["Cantidad"])
                                    };
                                    miBussinesInventario.ActualizarInventario(inventario, true);
                                }
                            }
                            else
                            {
                                stop = true;
                            }
                            numero = UseObject.NumberIncrement(numero);
                        }
                        OptionPane.MessageInformation("Los registros de venta se actualizarion correctamente.");
                        txtNumeroFactura.Text = "";
                    }
                    else
                    {
                        OptionPane.MessageInformation("El número que ingreso no tiene registro.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                miError.SetError(txtNumeroFactura, "El campo de Número de Factura Venta es requerido.");
            }
        }

        private void btnActCompra_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNumeroCompra.Text))
            {
                miError.SetError(txtNumeroCompra, null);
                try
                {
                    var bussinesFacturaCompra = new BussinesFacturaProveedor();
                    var tFactura = bussinesFacturaCompra.ConsultaFacturaProveedor(txtNumeroCompra.Text, true);
                    if (tFactura.Rows.Count != 0)
                    {
                        var row = tFactura.AsEnumerable().First();
                        var tProductos = bussinesFacturaCompra.
                                         ConsultaProductoFacturaProveedor(Convert.ToInt32(row["Id"]));
                        foreach (DataRow pRow in tProductos.Rows)
                        {
                            var inventario = new DTO.Clases.Inventario
                            {
                                CodigoProducto = pRow["Codigo"].ToString(),
                                IdMedida = Convert.ToInt32(pRow["IdMedida"]),
                                IdColor = Convert.ToInt32(pRow["IdColor"]),
                                Cantidad = Convert.ToDouble(pRow["Cantidad"])
                            };
                            miBussinesInventario.ActualizarInventario(inventario, false);
                        }
                        OptionPane.MessageInformation("Los registros de compra se actualizarion correctamente.");
                        txtNumeroCompra.Text = "";
                    }
                    else
                    {
                        OptionPane.MessageInformation("No se encontraron registros con ese número de factura.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                miError.SetError(txtNumeroCompra, "El campo es requerido.");
            }
        }
    }
}