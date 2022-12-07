using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using BussinesLayer.Clases;

namespace Aplicacion.Administracion.Sorteo
{
    public partial class frmDetalleSorteo : Form
    {
        

        private BussinesSorteo miBussinesSorteo;

        private frmSorteo frmsorteo = new frmSorteo();

        private DTO.Clases.Sorteo miSorteo;

        public frmDetalleSorteo()
        {
            InitializeComponent();

            miBussinesSorteo = new BussinesSorteo();
            frmsorteo = new frmSorteo();
            miSorteo = new DTO.Clases.Sorteo();
            
        }

        private void frmDetalleSorteo_Load(object sender, EventArgs e)
        {
           
        }

        private DataTable mitable;

        public void CargaDetalleSorteo(int idSorteo, bool historial)
        {                         
            mitable = frmsorteo.General();
            try
            {
                if (historial)
                {
                    miSorteo = miBussinesSorteo.CargaSorteo(idSorteo, true);
                }
                else
                {
                    miSorteo = miBussinesSorteo.CargaSorteo(idSorteo,false);
                }
                txtDetalleNombre.Text = miSorteo.NombreSorteo;
                txtDetalleConcepto.Text = miSorteo.Concepto;
                txtDetallePatrocinador.Text = miSorteo.PatrocinadoresSorteo;
                txtDetallePremio.Text = miSorteo.PremioSorteo;
                txtDetalleValorMinimoCompra.Text = miSorteo.ValorMinimoCompraSorteo.ToString();
                txtDetalleValorPremio.Text = miSorteo.ValorPremio.ToString();
                txtDetalleTipoSorteo.Text = miSorteo.NombreTipoSorteo;
                if (miSorteo.AplicaVenta)
                {
                    txtDetalleAplicaVenta.Text = "Venta minima";
                }
                else
                {
                    txtDetalleAplicaVenta.Text = "Tiquete Multiple";
                }
                if (miSorteo.TiqueteMultiple)
                {
                    txtDetalleTipoTiquete.Text = "Tiquete por factura";
                }
                else
                {
                    txtDetalleTipoTiquete.Text = "Tiquete por Producto";
                }
                txtDetalleFchaInicio.Text = miSorteo.FechaInicioSorteo.ToShortDateString();
                txtDetalleFechaFin.Text = miSorteo.FechaFinalSorteo.ToShortDateString();
                txtDetalleFechaSorteo.Text = miSorteo.FechaSorteo.ToShortDateString();
                if (miSorteo.AplicaHora)
                {
                    txtDetalleAplicaHora.Text = "Si";
                    txtDetalleHoraFin.Text = miSorteo.HoraFin.ToShortTimeString();
                    txtDetalleHoraInicio.Text = miSorteo.HoraInicio.ToShortTimeString();
                }
                else
                {
                    txtDetalleAplicaHora.Text = "No";
                }
                if (miSorteo.IdTipoSorteo == 2)
                {
                    var detalleSorteo = new frmDetalleSorteo();
                    detalleSorteo.Size = new System.Drawing.Size(985, 509);
                    gbxDetalleSeleccionar.Text = "Marcas del sorteo";
                    foreach (Marca m in miSorteo.Marcas)
                    {
                        var row = mitable.NewRow();
                        row["Codigo"] = m.IdMarca;
                        row["Nombre"] = m.NombreMarca;
                        mitable.Rows.Add(row);
                    }
                }
                else
                {
                    if (miSorteo.IdTipoSorteo == 3)
                    {
                        frmDetalleSorteo detalleSorteo = new frmDetalleSorteo();
                        detalleSorteo.Size = new System.Drawing.Size(985, 509);
                        gbxDetalleSeleccionar.Text = "Categorias de sorteo";
                        foreach (Categoria c in miSorteo.Categorias)
                        {
                            var row = mitable.NewRow();
                            row["Codigo"] = c.CodigoCategoria;
                            row["Nombre"] = c.NombreCategoria;
                            mitable.Rows.Add(row);
                        }
                    }
                    else
                    {
                        if (miSorteo.IdTipoSorteo == 4)
                        {
                            frmDetalleSorteo detalleSorteo = new frmDetalleSorteo();
                            detalleSorteo.Size = new System.Drawing.Size(985, 509);
                            gbxDetalleSeleccionar.Text = "Productos de el sorteo";
                            foreach (Producto p in miSorteo.Producto)
                            {
                                var row = mitable.NewRow();
                                row["Codigo"] = p.CodigoInternoProducto;
                                row["Nombre"] = p.NombreProducto;
                                mitable.Rows.Add(row);
                            }
                        }                        
                    }
                }

                if (historial)
                {
                    gbxDetalleGanador.Visible = true;
                    var micliente = miBussinesSorteo.HistorialClienteGanador(idSorteo);
                    txtDetalledocuGanador.Text = micliente.NitCliente;
                    txtDetalleNombreGanador.Text = micliente.NombresCliente;                    
                    txtDetalleTelefonoGanador.Text = micliente.TelefonoCliente;
                    txtDetallecelGanador.Text = micliente.CelularCliente;
                    txtDetalleNFacturaGanador.Text = micliente.IdCiudad.ToString();
                }
                    dgvDetalleMarcacategoriaPriducto.AutoGenerateColumns = false;
                    dgvDetalleMarcacategoriaPriducto.DataSource = mitable;                   

                }                        
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
