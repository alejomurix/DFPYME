using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utilities;
using CustomControl;

namespace Aplicacion.Principal
{
    public partial class frmPrincipal : Form
    {
        private DTO.Clases.Usuario Usuario_ { set; get; }

        private bool CargaCliente { set; get; }

        public bool _ConsultaInventario;

        private BussinesLayer.Clases.BussinesUsuario miBussinesUsuario;

        private BussinesLayer.Clases.BussinesDian miBussinesDian;

        private const int IdConfiguracion = 1;

        private const int IdAdministrar = 2;

        private const int IdInventario = 3;

        private const int IdEntradaSalidaInventario = 90;

        private const int IdTercero = 4;

        private const int IdProveedor = 5;

        private const int IdIngPreIngreso = 6;

        private const int IdConsPreIngreso = 7;

        private const int IdIngFacturaProveedor = 10;

        private const int IdConsFacturaProveedor = 11;

        private const int IdConsRemisionCompra = 14;

        private const int IdConsCarteraRemisionCompra = 15;

        private const int IdIngresarEgreso = 20;

        private const int IdConsultaEgreso = 21;

        private const int IdIngDevolCompra = 24;

        private const int IdConsDevolCompra = 26;

        private const int IdConsCarteraProveedor = 27;


        private const int IdIngresarCliente = 28;

        private const int IdIngAnticipoCliente = 31;

        private const int IdConsAnticipoCliente = 32;

        private const int IdAperturaCaja = 35;

        private const int IdCierreCaja = 36;

        private const int IdConsMovCaja = 37;

        private const int IdEditarPrecioProducto = 41;

        private const int IdConsPrecioProducto = 43;

        private const int IdFacturaVenta = 44;

        private const int IdFacturaPos = 45;

        private const int IdConsultaVentas = 52;

        private const int IdRemisionVenta = 56;

        private const int IdRemisionPos = 57;

        private const int IdConsRemisionVenta = 62;

        private const int IdConsCarteraRemisionVenta = 66;

        private const int IdIngDevolucionVenta = 67;

        private const int IdConsDevolucionVenta = 69;

        private const int IdIngDevolRemisionVenta = 70;

        private const int IdCanjeArticulo = 72;

        private const int IdIngresarOtroIngreso = 73;

        private const int IdConsultaOtroIngreso = 74;

        private const int IdConsultaIngresos = 76;

        private const int IdConsCarteraCliente = 77;

        private const int IdReporteCajaDiario = 78;

        private const int IdResumenVentas = 79;

        private const int IdResumenVentasCategoria = 80;

        private const int IdTesoreria = 81;

        public frmPrincipal()
        {
            //miBussinesUsuario = new BussinesLayer.Clases.BussinesUsuario();
            miBussinesApertura = new BussinesLayer.Clases.BussinesApertura();
            InitializeComponent();
            try
            {
                miBussinesUsuario = new BussinesLayer.Clases.BussinesUsuario();
                CargaCliente = Convert.ToBoolean(AppConfiguracion.ValorSeccion("cargarCliente"));
                _ConsultaInventario = Convert.ToBoolean(AppConfiguracion.ValorSeccion("frm_consulta_inventario"));

                /*if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("electronic_invoice"))) // true; habilita menu fact. electronica.
                {
                    this.empresaToolStripMenuItem.Visible = false;
                    this.menuCliente.Visible = false;
                    this.documentoElectronicoToolStripMenuItem.Visible = true;
                }
                else  // false; inahabilita menu fact. electronica.
                {
                    this.empresaToolStripMenuItem.Visible = true;
                    this.menuCliente.Visible = true;
                    this.documentoElectronicoToolStripMenuItem.Visible = false;
                }*/

                /*this.empresaToolStripMenuItem.Visible = true;
                this.menuCliente.Visible = true;
                this.documentoElectronicoToolStripMenuItem.Visible = false;*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        Configuracion.Conexion.FrmConexion conexion = null;
        private bool con = false;

        private void sbConexion_Click(object sender, EventArgs e)
        {
            if (con)
                conexion = null;
            try
            {
                Configuracion.Conexion.FrmConexion c =
                    (Configuracion.Conexion.FrmConexion)this.ActiveMdiChild;
                if (c == null)
                {
                    conexion = new Configuracion.Conexion.FrmConexion();
                    conexion.MdiParent = this;
                    conexion.Show();
                    con = true;
                }
                else
                    con = false;
            }
            catch
            {
                if (conexion == null)
                {
                    conexion =
                        new Configuracion.Conexion.FrmConexion();
                    conexion.MdiParent = this;
                    conexion.Show();
                    con = true;
                }
                else
                    con = false;
            }
        }

        Inventario.Producto.FrmIngresarProducto miProducto = null;
        private bool prod = false;

        private void sbProducto_Click(object sender, EventArgs e)
        {
            if (prod)
                miProducto = null;
            try
            {
                Inventario.Producto.FrmIngresarProducto p =
                    (Inventario.Producto.FrmIngresarProducto)this.ActiveMdiChild;
                if (p == null)
                {
                    miProducto =
                        new Inventario.Producto.FrmIngresarProducto();
                    miProducto.MdiParent = this;
                    miProducto.Show();
                    prod = true;
                }
                else
                    prod = false;
            }
            catch
            {
                if (miProducto == null)
                {
                    miProducto =
                        new Inventario.Producto.FrmIngresarProducto();
                    miProducto.MdiParent = this;
                    miProducto.Show();
                    prod = true;
                }
                else
                    prod = false;
            }
        }

        Compras.IngresarCompra.FrmIngresarCompra compra = null;
        bool comp = false;

        private void sbIngresarCompra_Click(object sender, EventArgs e)
        {
            /*var idBase = Utilities.AppConfiguracion.ValorSeccion("id_base");
            if (String.IsNullOrEmpty(idBase))
            {
                CustomControl.OptionPane.MessageInformation
                    ("Debe realizar apertura de caja para ingresar una Factura de Proveedor.");
            }
            else
            {
                if (comp)
                    compra = null;
                try
                {
                    Compras.IngresarCompra.FrmIngresarCompra c =
                        (Compras.IngresarCompra.FrmIngresarCompra)this.ActiveMdiChild;
                    if (c == null)
                    {
                        compra = new Compras.IngresarCompra.FrmIngresarCompra();
                        compra.MdiParent = this;
                        compra.Show();
                        comp = true;
                    }
                    else
                        comp = false;
                }
                catch
                {
                    if (compra == null)
                    {
                        compra = new Compras.IngresarCompra.FrmIngresarCompra();
                        compra.MdiParent = this;
                        compra.Show();
                        comp = true;
                    }
                    else
                        comp = false;
                }
            }*/
        }

        private void Contab_Load(object sender, EventArgs e)
        {
            //conection = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("conection"));
            try
            {
                //HabilitarMenu();
                HabilitarMenuCosultaCompra
                (Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("menuConsCompra")));
                if (Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("install"))) //Compilacion para instalar
                {
                    Utilities.AppConfiguracion.SaveConfiguration("report", Application.StartupPath);
                }
                else
                {
                    Utilities.AppConfiguracion.SaveConfiguration("report", "C:");
                }
                var frmAcceso = new Administracion.Usuario.FrmAcceso();
                frmAcceso.MdiParent = this;
                frmAcceso.Show();

                /* var frmPass = new Administracion.Usuario.FrmLoginPassword();
                 frmPass.MdiParent = this;
                 frmPass.Show();*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        Compras.Proveedor.frmProveedor provee = null;
        bool pro = false;

        private void sbProveedor_Click(object sender, EventArgs e)
        {
            if (pro)
                provee = null;
            try
            {
                Compras.Proveedor.frmProveedor p =
                    (Compras.Proveedor.frmProveedor)this.ActiveMdiChild;
                if (p == null)
                {
                    provee = new Compras.Proveedor.frmProveedor();
                    provee.MdiParent = this;
                    provee.Show();
                    pro = true;
                }
                else
                    pro = false;
            }
            catch
            {
                if (provee == null)
                {
                    provee = new Compras.Proveedor.frmProveedor();
                    provee.MdiParent = this;
                    provee.Show();
                    pro = true;
                }
                else
                    pro = false;
            }
        }

        Ventas.Cliente.frmCliente cliente = null;
        bool cli = false;

        FormulariosSistema.FrmCustomer frmCustomer = null;
        bool frmCustomer_ = false;

        private void sbMenuClientes_Click_(object sender, EventArgs e)
        {
            if (frmCustomer_)
                frmCustomer = null;
            try
            {
                FormulariosSistema.FrmCustomer c =
                    (FormulariosSistema.FrmCustomer)this.ActiveMdiChild;
                if (c == null)
                {
                    frmCustomer = new FormulariosSistema.FrmCustomer();
                    frmCustomer.MdiParent = this;
                    frmCustomer.Show();
                    // cliente.txtNit.Focus();
                    frmCustomer_ = true;
                }
                else
                    frmCustomer_ = false;
            }
            catch
            {
                if (frmCustomer == null)
                {
                    frmCustomer = new FormulariosSistema.FrmCustomer();
                    frmCustomer.MdiParent = this;
                    frmCustomer.Show();
                    // cliente.txtNit.Focus();
                    frmCustomer_ = true;
                }
                else
                    frmCustomer_ = false;
            }
        }

        private void sbMenuClientes_Click(object sender, EventArgs e)
        {
            /*
            if (frmCustomer_)
                frmCustomer = null;
            try
            {
                FormulariosSistema.FrmCustomer c =
                    (FormulariosSistema.FrmCustomer)this.ActiveMdiChild;
                if (c == null)
                {
                    frmCustomer = new FormulariosSistema.FrmCustomer();
                    frmCustomer.MdiParent = this;
                    frmCustomer.Show();
                   // cliente.txtNit.Focus();
                    frmCustomer_ = true;
                }
                else
                    frmCustomer_ = false;
            }
            catch
            {
                if (frmCustomer == null)
                {
                    frmCustomer = new FormulariosSistema.FrmCustomer();
                    frmCustomer.MdiParent = this;
                    frmCustomer.Show();
                   // cliente.txtNit.Focus();
                    frmCustomer_ = true;
                }
                else
                    frmCustomer_ = false;
            }
            */
        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        Inventario.Consulta.FrmConsultaInventario invCons = null;
        bool invc = false;

        Inventario.Consulta.FrmInventario frmInventario = null;
        bool frmInventario_ = false;

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ConsultaInventario)
            {
                if (invc)
                    invCons = null;
                try
                {
                    Inventario.Consulta.FrmConsultaInventario ic =
                        (Inventario.Consulta.FrmConsultaInventario)this.ActiveMdiChild;
                    if (ic == null)
                    {
                        invCons = new Inventario.Consulta.FrmConsultaInventario();
                        invCons.MdiParent = this;
                        invCons.Show();
                        invc = true;
                    }
                    else
                        invc = false;
                }
                catch
                {
                    if (invCons == null)
                    {
                        invCons = new Inventario.Consulta.FrmConsultaInventario();
                        invCons.MdiParent = this;
                        invCons.Show();
                        invc = true;
                    }
                    else
                        invc = false;
                }
            }
            else
            {
                if (frmInventario_)
                    frmInventario = null;
                try
                {
                    Inventario.Consulta.FrmInventario ic =
                        (Inventario.Consulta.FrmInventario)this.ActiveMdiChild;
                    if (ic == null)
                    {
                        frmInventario = new Inventario.Consulta.FrmInventario();
                        frmInventario.MdiParent = this;
                        frmInventario.Show();
                        frmInventario_ = true;
                    }
                    else
                        frmInventario_ = false;
                }
                catch
                {
                    if (frmInventario == null)
                    {
                        frmInventario = new Inventario.Consulta.FrmInventario();
                        frmInventario.MdiParent = this;
                        frmInventario.Show();
                        frmInventario_ = true;
                    }
                    else
                        frmInventario_ = false;
                }
            }
        }

        Inventario.Cruce.frmCruce cruce = null;
        private bool cr = false;

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cr)
                cruce = null;
            try
            {
                Inventario.Cruce.frmCruce c =
                    (Inventario.Cruce.frmCruce)this.ActiveMdiChild;
                if (c == null)
                {
                    cruce = new Inventario.Cruce.frmCruce();
                    cruce.MdiParent = this;
                    cruce.Show();
                    cr = true;
                }
                else
                    cr = false;
            }
            catch
            {
                if (cruce == null)
                {
                    cruce = new Inventario.Cruce.frmCruce();
                    cruce.MdiParent = this;
                    cruce.Show();
                    cr = true;
                }
                else
                    cr = false;
            }
        }

        Inventario.Cruce.frmRelacion relacion = null;
        private bool rel = false;

        private void cruzarYRevisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rel)
                relacion = null;
            try
            {
                Inventario.Cruce.frmRelacion r =
                    (Inventario.Cruce.frmRelacion)this.ActiveMdiChild;
                if (r == null)
                {
                    relacion = new Inventario.Cruce.frmRelacion();
                    relacion.MdiParent = this;
                    relacion.Show();
                    rel = true;
                }
                else
                    rel = false;
            }
            catch
            {
                if (relacion == null)
                {
                    relacion = new Inventario.Cruce.frmRelacion();
                    relacion.MdiParent = this;
                    relacion.Show();
                    rel = true;
                }
                else
                    rel = false;
            }
        }

        Configuracion.Marcas.FrmMarcaNuevo marca = null;
        private bool ma = false;

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ma)
                marca = null;
            try
            {
                Configuracion.Marcas.FrmMarcaNuevo m =
                    (Configuracion.Marcas.FrmMarcaNuevo)this.ActiveMdiChild;
                if (m == null)
                {
                    marca = new Configuracion.Marcas.FrmMarcaNuevo();
                    marca.MdiParent = this;
                    marca.Show();
                    ma = true;
                }
                else
                    ma = false;
            }
            catch
            {
                if (marca == null)
                {
                    marca = new Configuracion.Marcas.FrmMarcaNuevo();
                    marca.MdiParent = this;
                    marca.Show();
                    ma = true;
                }
                else
                    ma = false;
            }
        }

        Configuracion.Medida.frmmedida medida = null;
        private bool me = false;

        private void medidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (me)
                medida = null;
            try
            {
                Configuracion.Medida.frmmedida m =
                    (Configuracion.Medida.frmmedida)this.ActiveMdiChild;
                if (m == null)
                {
                    medida = new Configuracion.Medida.frmmedida();
                    medida.MdiParent = this;
                    medida.Show();
                    me = true;
                }
                else
                    me = false;
            }
            catch
            {
                if (medida == null)
                {
                    medida = new Configuracion.Medida.frmmedida();
                    medida.MdiParent = this;
                    medida.Show();
                    me = true;
                }
                else
                    me = false;
            }
        }

        Administracion.Dian.frmDian dian = null;
        private bool di = false;

        private void dianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (di)
                dian = null;
            try
            {
                Administracion.Dian.frmDian d =
                    (Administracion.Dian.frmDian)this.ActiveMdiChild;
                if (d == null)
                {
                    dian = new Administracion.Dian.frmDian();
                    dian.MdiParent = this;
                    dian.Show();
                    di = true;
                }
                else
                    di = false;
            }
            catch
            {
                if (dian == null)
                {
                    dian = new Administracion.Dian.frmDian();
                    dian.MdiParent = this;
                    dian.Show();
                    di = true;
                }
                else
                    di = false;
            }
        }

        Administracion.Iva.frmIva iva = null;
        bool iv = false;

        private void iVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iv)
                iva = null;
            try
            {
                Administracion.Iva.frmIva i =
                    (Administracion.Iva.frmIva)this.ActiveMdiChild;
                if (i == null)
                {
                    iva = new Administracion.Iva.frmIva();
                    iva.MdiParent = this;
                    iva.Show();
                    iv = true;
                }
                else
                    iv = false;
            }
            catch
            {
                if (iva == null)
                {
                    iva = new Administracion.Iva.frmIva();
                    iva.MdiParent = this;
                    iva.Show();
                    iv = true;
                }
                else
                    iv = false;
            }
        }

        Administracion.DescuentosYRecargos.frmDescuentosYRecargos descto = null;
        bool des = false;

        private void descuentosYRecargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (des)
                descto = null;
            try
            {
                Administracion.DescuentosYRecargos.frmDescuentosYRecargos d =
                    (Administracion.DescuentosYRecargos.frmDescuentosYRecargos)this.ActiveMdiChild;
                if (d == null)
                {
                    descto = new Administracion.DescuentosYRecargos.frmDescuentosYRecargos();
                    descto.MdiParent = this;
                    descto.Show();
                    des = true;
                }
                else
                    des = false;
            }
            catch
            {
                if (descto == null)
                {
                    descto = new Administracion.DescuentosYRecargos.frmDescuentosYRecargos();
                    descto.MdiParent = this;
                    descto.Show();
                    des = true;
                }
                else
                    des = false;
            }
        }

        Inventario.Categoria.FrmCategoriaNuevo categoria = null;
        private bool categ = false;

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (categ)
                categoria = null;
            try
            {
                Inventario.Categoria.FrmCategoriaNuevo c =
                    (Inventario.Categoria.FrmCategoriaNuevo)this.ActiveMdiChild;
                if (c == null)
                {
                    categoria =
                        new Inventario.Categoria.FrmCategoriaNuevo();
                    categoria.MdiParent = this;
                    categoria.Show();
                    categ = true;
                }
                else
                    categ = false;
            }
            catch
            {
                if (categoria == null)
                {
                    categoria =
                        new Inventario.Categoria.FrmCategoriaNuevo();
                    categoria.MdiParent = this;
                    categoria.Show();
                    categ = true;
                }
                else
                    categ = false;
            }
        }

        Compras.IngresarCompra.FrmConsulta consCompra = null;
        bool consc = false;

        private void consultarFacturaProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (consc)
                consCompra = null;
            try
            {
                Compras.IngresarCompra.FrmConsulta c =
                    (Compras.IngresarCompra.FrmConsulta)this.ActiveMdiChild;
                if (c == null)
                {
                    consCompra = new Compras.IngresarCompra.FrmConsulta();
                    consCompra.MdiParent = this;
                    consCompra.Show();
                    consc = true;
                }
                else
                    consc = false;
            }
            catch
            {
                if(consCompra == null)
                {
                    consCompra = new Compras.IngresarCompra.FrmConsulta();
                    consCompra.MdiParent = this;
                    consCompra.Show();
                    consc = true;
                }
                else
                    consc = false;
            }*/
        }

        Ventas.Factura.FrmFacturaVenta venta = null;
        bool v = false;

        // 
        private void facturarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_caja")))
            {
                try
                {
                    miBussinesDian = new BussinesLayer.Clases.BussinesDian();
                    miBussinesApertura = new BussinesLayer.Clases.BussinesApertura();
                    var execute = false;
                    if (miBussinesDian.ConsultaDian().Rows.Count != 0)
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqApertura")))
                        {
                            if (!miBussinesApertura.RegistrosApertura(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Rows.Count.Equals(0))  // if (!String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_apertura")))
                            {
                                execute = true;
                            }
                            else
                            {
                                execute = false;
                            }
                        }
                        else
                        {
                            execute = true;
                        }

                        if (execute)
                        {
                            if (v)
                                venta = null;
                            try
                            {
                                Ventas.Factura.FrmFacturaVenta ve =
                                    (Ventas.Factura.FrmFacturaVenta)this.ActiveMdiChild;
                                if (ve == null)
                                {
                                    venta = new Ventas.Factura.FrmFacturaVenta();
                                    venta.Usuario_ = this.Usuario_;
                                    venta.FacturaPos = false;
                                    venta.CargaCliente = CargaCliente;
                                    venta.MdiParent = this;
                                    venta.Show();
                                    if (CargaCliente)
                                    {
                                        venta.txtCodigoArticulo.Focus();
                                    }
                                    else
                                    {
                                        venta.txtCliente.Focus();
                                    }
                                    v = true;
                                }
                                else
                                    v = false;
                            }
                            catch
                            {
                                if (venta == null)
                                {
                                    venta = new Ventas.Factura.FrmFacturaVenta();
                                    venta.Usuario_ = this.Usuario_;
                                    venta.FacturaPos = false;
                                    venta.CargaCliente = CargaCliente;
                                    venta.MdiParent = this;
                                    venta.Show();
                                    if (CargaCliente)
                                    {
                                        venta.txtCodigoArticulo.Focus();
                                    }
                                    else
                                    {
                                        venta.txtCliente.Focus();
                                    }
                                    v = true;
                                }
                                else
                                    v = false;
                            }
                        }
                        else
                        {
                            OptionPane.MessageError("Debe realizar la apertura de caja antes de continuar.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageError("Debe asignar la numeración de la Dian para facturar ventas.");
                    }

                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageError("La estación no tiene configuración de caja.");
            }
        }

        Ventas.Factura.FrmFacturaPos ventaPOS = null;
        bool vPOS = false;
        // pos
        private void facturaPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_caja")))
            {
                try
                {
                    miBussinesDian = new BussinesLayer.Clases.BussinesDian();
                    miBussinesApertura = new BussinesLayer.Clases.BussinesApertura();
                    var execute = false;
                    if (miBussinesDian.ConsultaDian().Rows.Count != 0)
                    {
                        /**if (this.miBussinesDian.FacturacionActiva("IdRegistroDian", "Factura") && 
                            Convert.ToBoolean(AppConfiguracion.ValorSeccion("bloquear_facturacion")))
                        {*/
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("reqApertura")))
                            {
                                if (!miBussinesApertura.RegistrosApertura(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Rows.Count.Equals(0))  //if (!String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_apertura")))
                                {
                                    execute = true;
                                }
                                else
                                {
                                    execute = false;
                                }
                            }
                            else
                            {
                                execute = true;
                            }
                        /**}
                        else
                        {
                            execute = false;
                        }
                        */

                        if (execute)
                        {
                            //frm ventaPOS
                            //bool vPOS
                            if (vPOS)
                                ventaPOS = null;
                            try
                            {
                                Ventas.Factura.FrmFacturaPos ve_ =
                                    (Ventas.Factura.FrmFacturaPos)this.ActiveMdiChild;
                                if (ve_ == null)
                                {
                                    ventaPOS = new Ventas.Factura.FrmFacturaPos();
                                    ventaPOS.Usuario_ = this.Usuario_;
                                    ventaPOS.FacturaPos = true;
                                    ventaPOS.CargaCliente = CargaCliente;
                                    ventaPOS.MdiParent = this;
                                    ventaPOS.Show();
                                    if (CargaCliente)
                                    {
                                        ventaPOS.txtCodigoArticulo.Focus();
                                    }
                                    else
                                    {
                                        ventaPOS.txtCliente.Focus();
                                    }
                                    vPOS = true;
                                }
                                else
                                    vPOS = false;
                            }
                            catch
                            {
                                if (ventaPOS == null)
                                {
                                    ventaPOS = new Ventas.Factura.FrmFacturaPos();
                                    ventaPOS.Usuario_ = this.Usuario_;
                                    ventaPOS.FacturaPos = true;
                                    ventaPOS.CargaCliente = CargaCliente;
                                    ventaPOS.MdiParent = this;
                                    ventaPOS.Show();
                                    if (CargaCliente)
                                    {
                                        ventaPOS.txtCodigoArticulo.Focus();
                                    }
                                    else
                                    {
                                        ventaPOS.txtCliente.Focus();
                                    }
                                    vPOS = true;
                                }
                                else
                                    vPOS = false;
                            }

                            /*ventaPOS = new Ventas.Factura.FrmFacturaVenta();
                            ventaPOS.FacturaPos = true;
                            ventaPOS.CargaCliente = CargaCliente;
                            ventaPOS.MdiParent = this;
                            ventaPOS.Show();
                            if (CargaCliente)
                            {
                                ventaPOS.txtCodigoArticulo.Focus();
                            }
                            else
                            {
                                ventaPOS.txtCliente.Focus();
                            }*/
                        }
                        else
                        {
                            ///OptionPane.MessageError("No esta habilitado para facturar.");
                            OptionPane.MessageError("Debe realizar la apertura de caja antes de continuar.");
                        }
                    }
                    else
                    {
                        OptionPane.MessageError("Debe asignar la numeración de la Dian para facturar ventas.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                OptionPane.MessageError("La estación no tiene configuración de caja.");
            }
        }

        Ventas.Factura.FrmConsulta ventaCons = null;
        bool venCons = false;

        private void consultarVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (venCons)
                ventaCons = null;
            try
            {
                Ventas.Factura.FrmConsulta ven =
                    (Ventas.Factura.FrmConsulta)this.ActiveMdiChild;
                if (ven == null)
                {
                    ventaCons = new Ventas.Factura.FrmConsulta();
                    ventaCons.Usuario_ = this.Usuario_;
                    ventaCons.MdiParent = this;
                    ventaCons.Show();
                    venCons = true;
                }
                else
                    venCons = false;
            }
            catch
            {
                if (ventaCons == null)
                {
                    ventaCons = new Ventas.Factura.FrmConsulta();
                    ventaCons.Usuario_ = this.Usuario_;
                    ventaCons.MdiParent = this;
                    ventaCons.Show();
                    venCons = true;
                }
                else
                    venCons = false;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor que indica si la conexión esta configurada.
        /// </summary>
        private bool conection;

        /// <summary>
        /// Habilita el menú que requiere la conexión configurada.
        /// </summary>
        public void HabilitarMenu()
        {
            try
            {
                this.miBussinesUsuario = new BussinesLayer.Clases.BussinesUsuario();
                this.conection = Convert.ToBoolean(Utilities.AppConfiguracion.ValorSeccion("conection"));
                this.empresaToolStripMenuItem.Enabled = conection;
                this.configuracionDeEstacionToolStripMenuItem.Enabled = conection;
                this.marcasToolStripMenuItem.Enabled = conection;
                this.medidasToolStripMenuItem.Enabled = conection;
                this.precioDeVentaToolStripMenuItem.Enabled = conection;
                this.inventariosToolStripMenuItem.Enabled = conection;
                this.formasDePagoToolStripMenuItem.Enabled = conection;
                this.formatosDeImpresionToolStripMenuItem.Enabled = conection;
                this.configuracionEnVentasToolStripMenuItem.Enabled = conection;
                this.configuracionEnComprasToolStripMenuItem.Enabled = conection;
                this.copiasDeSeguridadToolStripMenuItem.Enabled = conection;
                this.informacionDelSistemaToolStripMenuItem.Enabled = conection;

                this.menuAdministrar.Enabled = conection;
                this.menuInventario.Enabled = conection;
                this.menuCompras.Enabled = conection;
                this.menuVentas.Enabled = conection;
                this.menuTesoreria.Enabled = conection;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void HabilitarMenu(DTO.Clases.Usuario usuario_)
        {
            this.Usuario_ = usuario_;
            foreach (var ps in usuario_.Permisos)
            {
                switch (ps.IdPermiso)
                {
                    case IdConfiguracion:
                        {
                            this.menuConfiguracion.Enabled = true;
                            break;
                        }
                    case IdAdministrar:
                        {
                            this.menuAdministrar.Enabled = true;
                            break;
                        }
                    case IdInventario:
                        {
                            this.menuInventario.Enabled = true;
                            break;
                        }
                    case IdEntradaSalidaInventario:
                        {
                            this.entradaYSalidaInventario.Enabled = true;
                            break;
                        }
                    case IdTercero:
                        {
                            this.MenuTerceros.Enabled = true;
                            break;
                        }
                    case IdProveedor:
                        {
                            this.sbProveedor.Enabled = true;
                            break;
                        }
                    case IdIngPreIngreso:
                        {
                            this.ingresarPreIngreso.Enabled = true;
                            break;
                        }
                    case IdConsPreIngreso:
                        {
                            this.consultarPreIngreso.Enabled = true;
                            break;
                        }
                    case IdIngFacturaProveedor:
                        {
                            this.ingresarFacturaProveedor.Enabled = true;
                            break;
                        }
                    case IdConsFacturaProveedor:
                        {
                            this.consultarFacturaProveedor.Enabled = true;
                            break;
                        }
                    case IdConsRemisionCompra:
                        {
                            this.menuConsultarRemisionCompra.Enabled = true;
                            break;
                        }
                    case IdConsCarteraRemisionCompra:
                        {
                            this.carteraRemisionCompra.Enabled = true;
                            break;
                        }
                    case IdIngresarEgreso:
                        {
                            this.menuIngresarEgreso.Enabled = true;
                            break;
                        }
                    case IdConsultaEgreso:
                        {
                            this.menuConsultaEgreso.Enabled = true;
                            break;
                        }
                    case IdIngDevolCompra:
                        {
                            this.ingresarDevolucionCompra.Enabled = true;
                            break;
                        }
                    case IdConsDevolCompra:
                        {
                            this.consultarDevolucionCompra.Enabled = true;
                            break;
                        }
                    case IdConsCarteraProveedor:
                        {
                            this.carteraDeProveedores.Enabled = true;
                            break;
                        }

                    //

                    case IdIngresarCliente:
                        {
                            this.menuCliente.Enabled = true;
                            break;
                        }
                    case IdIngAnticipoCliente:
                        {
                            this.menuNuevoAnticipoCliente.Enabled = true;
                            break;
                        }
                    case IdConsAnticipoCliente:
                        {
                            this.menuConsultaAnticipoCliente.Enabled = true;
                            break;
                        }
                    case IdAperturaCaja:
                        {
                            this.menuAperturaCaja.Enabled = true;
                            break;
                        }
                    case IdCierreCaja:
                        {
                            this.menuCierreCaja.Enabled = true;
                            break;
                        }
                    case IdConsMovCaja:
                        {
                            this.menuConsultaCaja.Enabled = true;
                            break;
                        }
                    case IdEditarPrecioProducto:
                        {
                            this.menuEditarPrecioProd.Enabled = true;
                            break;
                        }
                    case IdConsPrecioProducto:
                        {
                            this.menuConsultarPrecio.Enabled = true;
                            break;
                        }
                    case IdFacturaVenta:
                        {
                            this.menuFacturarVenta.Enabled = true;
                            break;
                        }
                    case IdFacturaPos:
                        {
                            this.menuFacturarPos.Enabled = true;
                            break;
                        }
                    case IdConsultaVentas:
                        {
                            this.menuConsultarVentas.Enabled = true;
                            break;
                        }
                    case IdRemisionVenta:
                        {
                            this.menuRemisionVenta.Enabled = true;
                            break;
                        }
                    case IdRemisionPos:
                        {
                            this.menuRemisionPos.Enabled = true;
                            break;
                        }
                    case IdConsRemisionVenta:
                        {
                            this.menuConsultaRemisionVenta.Enabled = true;
                            break;
                        }
                    case IdConsCarteraRemisionVenta:
                        {
                            this.menuCarteraRemVenta.Enabled = true;
                            break;
                        }
                    case IdIngDevolucionVenta:
                        {
                            this.menuIngresarDevolucionVenta.Enabled = true;
                            break;
                        }
                    case IdConsDevolucionVenta:
                        {
                            this.menuConsultaDevolVenta.Enabled = true;
                            break;
                        }
                    case IdIngDevolRemisionVenta:
                        {
                            this.menuIngDevolRemVenta.Enabled = true;
                            break;
                        }
                    case IdCanjeArticulo:
                        {
                            this.menuCanjeProducto.Enabled = true;
                            break;
                        }
                    case IdIngresarOtroIngreso:
                        {
                            this.menuOtroIngreso.Enabled = true;
                            break;
                        }
                    case IdConsultaOtroIngreso:
                        {
                            this.menuConsultaOtroIngreso.Enabled = true;
                            break;
                        }
                    case IdConsultaIngresos:
                        {
                            this.menuConsultaIngresos.Enabled = true;
                            break;
                        }
                    case IdConsCarteraCliente:
                        {
                            this.menuCarteraDeClientes.Enabled = true;
                            break;
                        }
                    case IdReporteCajaDiario:
                        {
                            this.menuReporteCajaDiario.Enabled = true;
                            break;
                        }
                    case IdResumenVentas:
                        {
                            this.menuResumenDeVentas.Enabled = true;
                            break;
                        }
                    case IdResumenVentasCategoria:
                        {
                            this.menuResumenDeVentasPorCategoria.Enabled = true;
                            break;
                        }

                    //

                    case IdTesoreria:
                        {
                            this.menuTesoreria.Enabled = true;
                            break;
                        }

                    //
                }
                this.sistemaToolStripMenuItem.Enabled = true;
            }

            this.menuCerrarSesion.Enabled = true;

            if (this.ingresarDevolucionCompra.Enabled || this.consultarDevolucionCompra.Enabled)
            {
                this.sbMenuCompraDevolucion.Enabled = true;
                this.menuDevolucionProveedor.Enabled = true;
            }
            if (this.ingresarPreIngreso.Enabled || this.consultarPreIngreso.Enabled)
            {
                this.menuPreingreso.Enabled = true;
            }
            if (this.ingresarFacturaProveedor.Enabled || this.consultarFacturaProveedor.Enabled)
            {
                this.sbIngresarCompra.Enabled = true;
            }
            if (this.menuConsultarRemisionCompra.Enabled || this.carteraRemisionCompra.Enabled)
            {
                this.menuRemisionesCompra.Enabled = true;
            }
            if (this.menuIngresarEgreso.Enabled || this.menuConsultaEgreso.Enabled)
            {
                this.menuEgresos.Enabled = true;
            }

            //

            if (this.menuNuevoAnticipoCliente.Enabled || this.menuConsultaAnticipoCliente.Enabled)
            {
                this.sbMenuAnticiposCliente.Enabled = true;
            }
            if (this.menuIngresarDevolucionVenta.Enabled || this.menuConsultaDevolVenta.Enabled)
            {
                this.sbMenuVentaDevolucion.Enabled = true;
            }
            if (this.menuCliente.Enabled || this.sbMenuAnticiposCliente.Enabled)
            {
                this.sbMenuClientes.Enabled = true;
            }
            if (this.menuAperturaCaja.Enabled || this.menuCierreCaja.Enabled || this.menuConsultaCaja.Enabled)
            {
                this.menuCaja.Enabled = true;
            }
            if (this.menuFacturarVenta.Enabled || this.menuFacturarPos.Enabled || this.menuConsultarVentas.Enabled)
            {
                this.menuFacturarVentas.Enabled = true;
            }
            if (this.menuRemisionVenta.Enabled || this.menuRemisionPos.Enabled ||
                this.menuConsultaRemisionVenta.Enabled || this.menuCarteraRemVenta.Enabled)
            {
                this.menuRemisionesVenta.Enabled = true;
            }
            if (this.sbMenuVentaDevolucion.Enabled || this.menuIngDevolRemVenta.Enabled || this.menuCanjeProducto.Enabled)
            {
                this.menuDevolucionVenta.Enabled = true;
            }
            if (this.menuOtroIngreso.Enabled || this.menuConsultaOtroIngreso.Enabled || this.menuConsultaIngresos.Enabled)
            {
                this.menuIngresos.Enabled = true;
            }
            if (this.menuResumenDeVentas.Enabled || this.menuResumenDeVentasPorCategoria.Enabled)
            {
                this.menuResumneDeUtilidades.Enabled = true;
            }

            if (this.MenuTerceros.Enabled ||
                this.sbProveedor.Enabled ||
                this.menuPreingreso.Enabled ||
                this.sbIngresarCompra.Enabled ||
                this.menuRemisionesCompra.Enabled ||
                this.menuEgresos.Enabled ||
                this.menuDevolucionProveedor.Enabled ||
                this.carteraDeProveedores.Enabled)
            {
                this.menuCompras.Enabled = true;
            }

            if (this.sbMenuClientes.Enabled ||
                this.menuCaja.Enabled ||
                this.menuEditarPrecioProd.Enabled ||
                this.menuConsultarPrecio.Enabled ||
                this.menuFacturarVentas.Enabled ||
                this.menuRemisionesVenta.Enabled ||
                this.menuDevolucionVenta.Enabled ||
                this.menuIngresos.Enabled ||
                this.menuCarteraDeClientes.Enabled ||
                this.menuReporteCajaDiario.Enabled ||
                this.menuResumneDeUtilidades.Enabled)
            {
                this.menuVentas.Enabled = true;
            }

            /* if (ps.IdPermiso.Equals(IdConexion))
             {
                 this.menuConfiguracion.Enabled = true;
             }
             else
             {
                 if (ps.IdPermiso.Equals(this.IdConfiguracion))
                 {
                     this.menuAdministrar.Enabled = true;
                 }
             }*/

            /* this.menuConfiguracion.Enabled = usuario_.Permiso.Configuracion;
             this.menuAdministrar.Enabled = usuario_.Permiso.Administrar;*/
        }

        public void HabilitarMenuCosultaCompra(bool actived)
        {
            this.MenuComprasDeProducto.Visible = actived;
        }

        public void InhabilitarMenu()
        {
            menuConfiguracion.Enabled
            = menuAdministrar.Enabled
            = menuInventario.Enabled
            = entradaYSalidaInventario.Enabled
            = MenuTerceros.Enabled
            = sbProveedor.Enabled
            = ingresarPreIngreso.Enabled
            = consultarPreIngreso.Enabled
            = ingresarFacturaProveedor.Enabled
            = consultarFacturaProveedor.Enabled
            = menuConsultarRemisionCompra.Enabled
            = carteraRemisionCompra.Enabled
            = menuIngresarEgreso.Enabled
            = menuConsultaEgreso.Enabled
            = ingresarDevolucionCompra.Enabled
            = consultarDevolucionCompra.Enabled
            = carteraDeProveedores.Enabled
            = menuCliente.Enabled
            = menuNuevoAnticipoCliente.Enabled
            = menuConsultaAnticipoCliente.Enabled
            = menuAperturaCaja.Enabled
            = menuCierreCaja.Enabled
            = menuConsultaCaja.Enabled
            = menuEditarPrecioProd.Enabled
            = menuConsultarPrecio.Enabled
            = menuFacturarVenta.Enabled
            = menuFacturarPos.Enabled
            = menuConsultarVentas.Enabled
            = menuRemisionVenta.Enabled
            = menuRemisionPos.Enabled
            = menuConsultaRemisionVenta.Enabled
            = menuCarteraRemVenta.Enabled
            = menuIngresarDevolucionVenta.Enabled
            = menuConsultaDevolVenta.Enabled
            = menuIngDevolRemVenta.Enabled
            = menuCanjeProducto.Enabled
            = menuOtroIngreso.Enabled
            = menuConsultaOtroIngreso.Enabled
            = menuConsultaIngresos.Enabled
            = menuCarteraDeClientes.Enabled
            = menuReporteCajaDiario.Enabled
            = menuResumenDeVentas.Enabled
            = menuResumenDeVentasPorCategoria.Enabled
            = menuTesoreria.Enabled
            = sistemaToolStripMenuItem.Enabled
            = sbMenuCompraDevolucion.Enabled
            = menuDevolucionProveedor.Enabled
            = menuPreingreso.Enabled
            = sbIngresarCompra.Enabled
            = menuRemisionesCompra.Enabled
            = menuEgresos.Enabled
            = sbMenuAnticiposCliente.Enabled
            = sbMenuVentaDevolucion.Enabled
            = sbMenuClientes.Enabled
            = menuCaja.Enabled
            = menuFacturarVentas.Enabled
            = menuRemisionesVenta.Enabled
            = menuDevolucionVenta.Enabled
            = menuIngresos.Enabled
            = menuResumneDeUtilidades.Enabled
            = menuCompras.Enabled
            = menuVentas.Enabled = false;
        }

        public void CargarCliente()
        {
            try
            {
                CargaCliente = Convert.ToBoolean(AppConfiguracion.ValorSeccion("cargarCliente"));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        Administracion.Caja.FrmAperturaCaja caja = null;
        bool cj = false;

        private void aperturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cj)
                caja = null;
            try
            {
                Administracion.Caja.FrmAperturaCaja caja1 =
                    (Administracion.Caja.FrmAperturaCaja)this.ActiveMdiChild;
                if (caja1 == null)
                {
                    caja = new Administracion.Caja.FrmAperturaCaja();
                    caja.MdiParent = this;
                    caja.Show();
                    cj = true;
                }
                else
                    cj = false;
            }
            catch
            {
                if (caja == null)
                {
                    caja = new Administracion.Caja.FrmAperturaCaja();
                    caja.MdiParent = this;
                    caja.Show();
                    cj = true;
                }
                else
                    cj = false;
            }

            /* string rta = "";
             bool userAdmin = false;
             if (cj)
                 caja = null;
             try
             {
                 try
                 {
                     Administracion.Caja.FrmAperturaCaja ca =
                         (Administracion.Caja.FrmAperturaCaja)this.ActiveMdiChild;
                     if (ca == null)
                     {
                         while (!userAdmin)
                         {
                             rta = CustomControl.OptionPane.OptionBox
                                 ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                             if (rta.Equals("false"))
                             {
                                 break;
                             }
                             else
                             {
                                 userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                 if (userAdmin)
                                 {
                                     caja = new Administracion.Caja.FrmAperturaCaja();
                                     caja.MdiParent = this;
                                     caja.Show();
                                     cj = true;
                                 }
                             }
                         }
                     }
                     else
                         cj = false;
                 }
                 catch
                 {
                     if (caja == null)
                     {
                         while (!userAdmin)
                         {
                             rta = CustomControl.OptionPane.OptionBox
                                 ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                             if (rta.Equals("false"))
                             {
                                 break;
                             }
                             else
                             {
                                 userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                 if (userAdmin)
                                 {
                                     caja = new Administracion.Caja.FrmAperturaCaja();
                                     caja.MdiParent = this;
                                     caja.Show();
                                     cj = true;
                                 }
                             }
                         }
                     }
                     else
                         cj = false;
                 }
             }
             catch (Exception ex)
             {
                 OptionPane.MessageError(ex.Message);
             }*/
        }

        Administracion.Caja.FrmConsultaCaja Ccaja = null;
        bool Ccj = false;

        private void consultasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Ccj)
                Ccaja = null;
            try
            {
                Administracion.Caja.FrmConsultaCaja Ccaja1 =
                    (Administracion.Caja.FrmConsultaCaja)this.ActiveMdiChild;
                if (Ccaja1 == null)
                {
                    Ccaja = new Administracion.Caja.FrmConsultaCaja();
                    Ccaja.Usuario_ = this.Usuario_;
                    Ccaja.MdiParent = this;
                    Ccaja.Show();
                    Ccj = true;
                }
                else
                    Ccj = false;
            }
            catch
            {
                if (Ccaja == null)
                {
                    Ccaja = new Administracion.Caja.FrmConsultaCaja();
                    Ccaja.Usuario_ = this.Usuario_;
                    Ccaja.MdiParent = this;
                    Ccaja.Show();
                    Ccj = true;
                }
                else
                    Ccj = false;
            }

            /*string rta = "";
            bool userAdmin = false;
            if (Ccj)
                Ccaja = null;
            try
            {
                try
                {
                    Administracion.Caja.FrmConsultaCaja Cca =
                        (Administracion.Caja.FrmConsultaCaja)this.ActiveMdiChild;
                    if (Cca == null)
                    {
                        while (!userAdmin)
                        {
                            rta = CustomControl.OptionPane.OptionBox
                                ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                            if (rta.Equals("false"))
                            {
                                break;
                            }
                            else
                            {
                                userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                if (userAdmin)
                                {
                                    Ccaja = new Administracion.Caja.FrmConsultaCaja();
                                    Ccaja.MdiParent = this;
                                    Ccaja.Show();
                                    Ccj = true;
                                }
                            }
                        }
                    }
                    else
                        Ccj = false;
                }
                catch
                {
                    if (Ccaja == null)
                    {
                        while (!userAdmin)
                        {
                            rta = CustomControl.OptionPane.OptionBox
                                ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                            userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                            if (userAdmin)
                            {
                                Ccaja = new Administracion.Caja.FrmConsultaCaja();
                                Ccaja.MdiParent = this;
                                Ccaja.Show();
                                Ccj = true;
                            }
                        }
                    }
                    else
                        Ccj = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
        }



        private void egresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*var idBase = Utilities.AppConfiguracion.ValorSeccion("id_base");
            if (String.IsNullOrEmpty(idBase))
            {
                CustomControl.OptionPane.MessageInformation
                    ("Debe realizar apertura de caja para realizar un Egreso.");
            }
            else
            {
                BussinesLayer.Clases.BussinesUsuario miBussinesUsuario =
                    new BussinesLayer.Clases.BussinesUsuario();
                string rta = "";
                if (com)
                    egreso = null;
                try
                {
                    Compras.Egreso.FrmEditarEgreso eg =
                        (Compras.Egreso.FrmEditarEgreso)this.ActiveMdiChild;
                    if (eg == null)
                    {
                        rta = CustomControl.OptionPane.OptionBox
                        ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (!rta.Equals("false"))
                        {
                            if (miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta)))
                            {
                                egreso = new Compras.Egreso.FrmEditarEgreso();
                                egreso.MdiParent = this;
                                egreso.Show();
                                com = true;
                            }
                        }
                    }
                    else
                        com = false;
                }
                catch
                {
                    if (egreso == null)
                    {
                        rta = CustomControl.OptionPane.OptionBox
                        ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (!rta.Equals("false"))
                        {
                            if (miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta)))
                            {
                                egreso = new Compras.Egreso.FrmEditarEgreso();
                                egreso.MdiParent = this;
                                egreso.Show();
                                com = true;
                            }
                        }
                    }
                    else
                        com = false;
                }
            }*/
        }


        Administracion.CajaDiario.FrmConsultaCajaFecha cajaD = null;
        bool cD = false;

        Administracion.CajaDiario.FrmConsultaCajaFecha58mm ccaja = null;
        bool ccj = false;

        private void reporteCajaDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("print_termal_80mm")))
            {
                if (cD)
                    cajaD = null;
                try
                {
                    Administracion.CajaDiario.FrmConsultaCajaFecha cj =
                        (Administracion.CajaDiario.FrmConsultaCajaFecha)this.ActiveMdiChild;
                    if (cj == null)
                    {
                        cajaD = new Administracion.CajaDiario.FrmConsultaCajaFecha();
                        cajaD.MdiParent = this;
                        cajaD.Show();
                        cD = true;
                    }
                    else
                        cD = false;
                }
                catch
                {
                    if (cajaD == null)
                    {
                        cajaD = new Administracion.CajaDiario.FrmConsultaCajaFecha();
                        cajaD.MdiParent = this;
                        cajaD.Show();
                        cD = true;
                    }
                    else
                        cD = false;
                }
            }
            else
            {
                if (ccj)
                    ccaja = null;
                try
                {
                    Administracion.CajaDiario.FrmConsultaCajaFecha58mm cj =
                        (Administracion.CajaDiario.FrmConsultaCajaFecha58mm)this.ActiveMdiChild;
                    if (cj == null)
                    {
                        ccaja = new Administracion.CajaDiario.FrmConsultaCajaFecha58mm();
                        ccaja.MdiParent = this;
                        ccaja.Show();
                        ccj = true;
                    }
                    else
                        ccj = false;
                }
                catch
                {
                    if (ccaja == null)
                    {
                        ccaja = new Administracion.CajaDiario.FrmConsultaCajaFecha58mm();
                        ccaja.MdiParent = this;
                        ccaja.Show();
                        ccj = true;
                    }
                    else
                        ccj = false;
                }
            }
            /*
            if (cD)
                cajaD = null;
            try
            {
                Administracion.CajaDiario.FrmConsultaCajaFecha cj =
                    (Administracion.CajaDiario.FrmConsultaCajaFecha)this.ActiveMdiChild;
                if (cj == null)
                {
                    cajaD = new Administracion.CajaDiario.FrmConsultaCajaFecha();
                    cajaD.MdiParent = this;
                    cajaD.Show();
                    cD = true;
                }
                else
                    cD = false;
            }
            catch
            {
                if (cajaD == null)
                {
                    cajaD = new Administracion.CajaDiario.FrmConsultaCajaFecha();
                    cajaD.MdiParent = this;
                    cajaD.Show();
                    cD = true;
                }
                else
                    cD = false;
            }
            */

            
            
        }

        Compras.Egreso.frmConsultarEgreso c_egreso = null;
        bool c_com = false;

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (c_com)
                c_egreso = null;
            try
            {
                Compras.Egreso.frmConsultarEgreso c_eg =
                    (Compras.Egreso.frmConsultarEgreso)this.ActiveMdiChild;
                if (c_eg == null)
                {
                    c_egreso = new Compras.Egreso.frmConsultarEgreso();
                    c_egreso.MdiParent = this;
                    c_egreso.Show();
                    c_com = true;
                }
                else
                    c_com = false;
            }
            catch
            {
                if (c_egreso == null)
                {
                    c_egreso = new Compras.Egreso.frmConsultarEgreso();
                    c_egreso.MdiParent = this;
                    c_egreso.Show();
                    c_com = true;
                }
                else
                    c_com = false;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de salir del Sistema?", "Salir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        Inventario.Arme.frmArme arme = null;
        bool arm = false;

        private void agrupacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*BussinesLayer.Clases.BussinesUsuario miBussinesUsuario =
                    new BussinesLayer.Clases.BussinesUsuario();*/
            if (arm)
                arme = null;
            var rta = CustomControl.OptionPane.OptionBox
                        ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
            if (!rta.Equals("false"))
            {
                try
                {
                    Inventario.Arme.frmArme ar =
                        (Inventario.Arme.frmArme)this.ActiveMdiChild;
                    if (ar == null)
                    {
                        arme = new Inventario.Arme.frmArme();
                        arme.AplicaDesagrupar = false;
                        arme.MdiParent = this;
                        arme.Show();
                        arm = true;
                    }
                    else
                        arm = false;
                }
                catch
                {
                    if (arme == null)
                    {
                        arme = new Inventario.Arme.frmArme();
                        arme.AplicaDesagrupar = false;
                        arme.MdiParent = this;
                        arme.Show();
                        arm = true;
                    }
                    else
                        arm = false;
                }
            }
            else
                CustomControl.OptionPane.MessageError("Contraseña incorrecta.");
        }

        Inventario.Arme.frmArme desarme = null;
        bool desarm = false;

        private void desAgrupacipnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*BussinesLayer.Clases.BussinesUsuario miBussinesUsuario =
                    new BussinesLayer.Clases.BussinesUsuario();*/
            if (desarm)
                desarme = null;
            var rta = CustomControl.OptionPane.OptionBox
                       ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
            if (!rta.Equals("false"))
            {
                try
                {
                    Inventario.Arme.frmArme desa =
                        (Inventario.Arme.frmArme)this.ActiveMdiChild;
                    if (desa == null)
                    {
                        desarme = new Inventario.Arme.frmArme();
                        desarme.AplicaDesagrupar = true;
                        desarme.MdiParent = this;
                        desarme.Show();
                        desarm = true;
                    }
                    else
                        desarm = false;
                }
                catch
                {
                    if (desarme == null)
                    {
                        desarme = new Inventario.Arme.frmArme();
                        desarme.AplicaDesagrupar = true;
                        desarme.MdiParent = this;
                        desarme.Show();
                        desarm = true;
                    }
                    else
                        desarm = false;
                }
            }
            else
                CustomControl.OptionPane.MessageError("Contraseña incorrecta.");
        }

        private void remisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // Ventas.Cliente.FrmAdelanto adelanto = null;
        //bool ade = false;

        private void adelentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ade)
                adelanto = null;
            try
            {
                Ventas.Cliente.FrmAdelanto ad =
                    (Ventas.Cliente.FrmAdelanto)this.ActiveMdiChild;
                if (ad == null)
                {
                    adelanto = new Ventas.Cliente.FrmAdelanto();
                    adelanto.MdiParent = this;
                    adelanto.Show();
                    ade = true;
                }
                else
                    ade = false;
            }
            catch
            {
                if (adelanto == null)
                {
                    adelanto = new Ventas.Cliente.FrmAdelanto();
                    adelanto.MdiParent = this;
                    adelanto.Show();
                    ade = true;
                }
                else
                    ade = false;
            }*/
        }

        Ventas.Remisiones.FrmRemision remision = null;
        bool rem = false;

        private void ingresarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (rem)
                remision = null;
            try
            {
                Ventas.Remisiones.FrmRemision ad =
                    (Ventas.Remisiones.FrmRemision)this.ActiveMdiChild;
                if (ad == null)
                {
                    remision = new Ventas.Remisiones.FrmRemision();
                    remision.Usuario_ = this.Usuario_;
                    //remision.Venta = true;
                    remision.CargaCliente = CargaCliente;
                    remision.MdiParent = this;
                    remision.Show();
                    if (CargaCliente)
                    {
                        remision.txtCodigoArticulo.Focus();
                    }
                    else
                    {
                        remision.txtCliente.Focus();
                    }
                    rem = true;
                }
                else
                    rem = false;
            }
            catch
            {
                if (remision == null)
                {
                    remision = new Ventas.Remisiones.FrmRemision();
                    remision.Usuario_ = this.Usuario_;
                    //remision.Venta = true;
                    remision.MdiParent = this;
                    remision.CargaCliente = CargaCliente;
                    remision.Show();
                    if (CargaCliente)
                    {
                        remision.txtCodigoArticulo.Focus();
                    }
                    else
                    {
                        remision.txtCliente.Focus();
                    }
                    rem = true;
                }
                else
                    rem = false;
            }
        }

        Ventas.Remisiones.FrmRemision remisionPos = null;
        bool remPos = false;

        private void remisiónPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (this.miBussinesDian.FacturacionActiva("IdRegistroDian", "Factura") && 
                Convert.ToBoolean(AppConfiguracion.ValorSeccion("bloquear_facturacion")))
            {*/
                remisionPos = new Ventas.Remisiones.FrmRemision();
                remisionPos.Usuario_ = this.Usuario_;
                remisionPos.FacturaPos = true;
                remisionPos.CargaCliente = CargaCliente;
                remisionPos.MdiParent = this;
                remisionPos.Show();
                if (CargaCliente)
                {
                    remisionPos.txtCodigoArticulo.Focus();
                }
                else
                {
                    remisionPos.txtCliente.Focus();
                }
            /*}
            else
            {
                OptionPane.MessageError("No esta habilitado para remisionar.");
                ///OptionPane.MessageError("Debe realizar la apertura de caja antes de continuar.");
            }*/
        }

        Ventas.Remisiones.FrmConsulta c_remision = null;
        bool c_rem = false;

        private void consultasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (c_rem)
                c_remision = null;
            try
            {
                Ventas.Remisiones.FrmConsulta ad =
                    (Ventas.Remisiones.FrmConsulta)this.ActiveMdiChild;
                if (ad == null)
                {
                    c_remision = new Ventas.Remisiones.FrmConsulta();
                    c_remision.Usuario_ = this.Usuario_;
                    c_remision.MdiParent = this;
                    c_remision.Show();
                    c_rem = true;
                }
                else
                    c_rem = false;
            }
            catch
            {
                if (c_remision == null)
                {
                    c_remision = new Ventas.Remisiones.FrmConsulta();
                    c_remision.Usuario_ = this.Usuario_;
                    c_remision.MdiParent = this;
                    c_remision.Show();
                    c_rem = true;
                }
                else
                    c_rem = false;
            }
        }

        //DEVOLUCION VENTA EDITADO...
        Ventas.Devolucion.Anterior.FrmDevolucionVenta dev_venta = null;
        bool dev_v = false;

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (dev_v)
                dev_venta = null;
            try
            {
                Ventas.Devolucion.FrmDevolucionVenta ad =
                    (Ventas.Devolucion.FrmDevolucionVenta)this.ActiveMdiChild;
                if (ad == null)
                {
                    dev_venta = new Ventas.Devolucion.Anterior.FrmDevolucionVenta();
                    dev_venta.MdiParent = this;
                    dev_venta.Show();
                    dev_v = true;
                }
                else
                    dev_v = false;
            }
            catch
            {
                if (dev_venta == null)
                {
                    dev_venta = new Ventas.Devolucion.Anterior.FrmDevolucionVenta();
                    dev_venta.MdiParent = this;
                    dev_venta.Show();
                    dev_v = true;
                }
                else
                    dev_v = false;
            }*/
        }

        Ventas.Devolucion.FrmDevolucionRemision dev_rem = null;
        bool dev_r = false;

        private void remisionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dev_r)
                dev_rem = null;
            try
            {
                Ventas.Devolucion.FrmDevolucionRemision ad =
                    (Ventas.Devolucion.FrmDevolucionRemision)this.ActiveMdiChild;
                if (ad == null)
                {
                    dev_rem = new Ventas.Devolucion.FrmDevolucionRemision();
                    dev_rem.MdiParent = this;
                    dev_rem.Show();
                    dev_r = true;
                }
                else
                    dev_r = false;
            }
            catch
            {
                if (dev_rem == null)
                {
                    dev_rem = new Ventas.Devolucion.FrmDevolucionRemision();
                    dev_rem.MdiParent = this;
                    dev_rem.Show();
                    dev_r = true;
                }
                else
                    dev_r = false;
            }
        }

        Ventas.Cliente.FrmBonos bono = null;
        bool bon = false;

        private void bonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bon)
                bono = null;
            try
            {
                Ventas.Cliente.FrmBonos ad =
                    (Ventas.Cliente.FrmBonos)this.ActiveMdiChild;
                if (ad == null)
                {
                    bono = new Ventas.Cliente.FrmBonos();
                    bono.MdiParent = this;
                    bono.Show();
                    bon = true;
                }
                else
                    bon = false;
            }
            catch
            {
                if (bono == null)
                {
                    bono = new Ventas.Cliente.FrmBonos();
                    bono.MdiParent = this;
                    bono.Show();
                    bon = true;
                }
                else
                    bon = false;
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (cli)
                cliente = null;
            try
            {
                Ventas.Cliente.frmCliente c =
                    (Ventas.Cliente.frmCliente)this.ActiveMdiChild;
                if (c == null)
                {
                    cliente = new Ventas.Cliente.frmCliente();
                    cliente.MdiParent = this;
                    cliente.Show();
                    cliente.txtNit.Focus();
                    cli = true;
                }
                else
                    cli = false;
            }
            catch
            {
                if (cliente == null)
                {
                    cliente = new Ventas.Cliente.frmCliente();
                    cliente.MdiParent = this;
                    cliente.Show();
                    cliente.txtNit.Focus();
                    cli = true;
                }
                else
                    cli = false;
            }
            
        }

        Configuracion.Empresa.frmEmpresa empresa = null;
        bool emp = false;

        FormulariosSistema.FrmCompany frmCompany = null;
        bool frmCompany_ = false;

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            if (frmCompany_)
                frmCompany = null;
            try
            {
                FormulariosSistema.FrmCompany empr =
                    (FormulariosSistema.FrmCompany)this.ActiveMdiChild;
                if (empr == null)
                {
                    frmCompany = new FormulariosSistema.FrmCompany();
                    frmCompany.MdiParent = this;
                    frmCompany.Show();
                    frmCompany_ = true;
                }
                else
                    frmCompany_ = false;
            }
            catch
            {
                if (frmCompany == null)
                {
                    frmCompany = new FormulariosSistema.FrmCompany();
                    frmCompany.MdiParent = this;
                    frmCompany.Show();
                    frmCompany_ = true;
                }
                else
                    frmCompany_ = false;
            }
            */

            
            if (emp)
                empresa = null;
            try
            {
                Configuracion.Empresa.frmEmpresa empr =
                    (Configuracion.Empresa.frmEmpresa)this.ActiveMdiChild;
                if (empr == null)
                {
                    empresa = new Configuracion.Empresa.frmEmpresa();
                    empresa.MdiParent = this;
                    empresa.Show();
                    emp = true;
                }
                else
                    emp = false;
            }
            catch
            {
                if (empresa == null)
                {
                    empresa = new Configuracion.Empresa.frmEmpresa();
                    empresa.MdiParent = this;
                    empresa.Show();
                    emp = true;
                }
                else
                    emp = false;
            }
        }

        private void consultarIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Compras.Egreso.FrmEditarEgreso egreso = null;
        bool com = false;

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (com)
                egreso = null;
            try
            {
                Compras.Egreso.FrmEditarEgreso egreso1 =
                    (Compras.Egreso.FrmEditarEgreso)this.ActiveMdiChild;
                if (egreso1 == null)
                {
                    egreso = new Compras.Egreso.FrmEditarEgreso();
                    egreso.MdiParent = this;
                    egreso.Show();
                    com = true;
                }
                else
                    com = false;
            }
            catch
            {
                if (egreso == null)
                {
                    egreso = new Compras.Egreso.FrmEditarEgreso();
                    egreso.MdiParent = this;
                    egreso.Show();
                    com = true;
                }
                else
                    com = false;
            }


            /*var idBase = Utilities.AppConfiguracion.ValorSeccion("id_base");
            if (String.IsNullOrEmpty(idBase))
            {
                CustomControl.OptionPane.MessageInformation
                    ("Debe realizar apertura de caja para realizar un Egreso.");
            }
            else
            {*/
            /*BussinesLayer.Clases.BussinesUsuario miBussinesUsuario =
                new BussinesLayer.Clases.BussinesUsuario();*/
            /*   string rta = "";
               if (com)
                   egreso = null;
               try
               {
                   try
                   {
                       Compras.Egreso.FrmEditarEgreso eg =
                           (Compras.Egreso.FrmEditarEgreso)this.ActiveMdiChild;
                       if (eg == null)
                       {
                           rta = CustomControl.OptionPane.OptionBox
                           ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                           if (!rta.Equals("false"))
                           {
                               if (miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta)))
                               {
                                   egreso = new Compras.Egreso.FrmEditarEgreso();
                                   egreso.MdiParent = this;
                                   egreso.Show();
                                   com = true;
                               }
                               else
                               {
                                   CustomControl.OptionPane.MessageError("Contraseña incorrecta.");
                               }
                           }
                       }
                       else
                           com = false;
                   }
                   catch
                   {
                       if (egreso == null)
                       {
                           rta = CustomControl.OptionPane.OptionBox
                           ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                           if (!rta.Equals("false"))
                           {
                               if (miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta)))
                               {
                                   egreso = new Compras.Egreso.FrmEditarEgreso();
                                   egreso.MdiParent = this;
                                   egreso.Show();
                                   com = true;
                               }
                           }
                       }
                       else
                           com = false;
                   }
               }
               catch (Exception ex)
               {
                   OptionPane.MessageError(ex.Message);
               }*/
            //}
        }

        Ventas.Ingresos.FrmConsultaIngreso ingresos = null;
        bool ing = false;

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ing)
                ingresos = null;
            try
            {
                Ventas.Ingresos.FrmConsultaIngreso ingre =
                    (Ventas.Ingresos.FrmConsultaIngreso)this.ActiveMdiChild;
                if (ingre == null)
                {
                    ingresos = new Ventas.Ingresos.FrmConsultaIngreso();
                    ingresos.MdiParent = this;
                    ingresos.Show();
                    ing = true;
                }
                else
                {
                    ing = false;
                }
            }
            catch
            {
                if (ingresos == null)
                {
                    ingresos = new Ventas.Ingresos.FrmConsultaIngreso();
                    ingresos.MdiParent = this;
                    ingresos.Show();
                    ing = true;
                }
                else
                    ing = false;
            }
        }

        private void retencionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Administracion.Retencion.FrmRetencion r = new Administracion.Retencion.FrmRetencion();
            r.MdiParent = this;
            r.Show();
        }

        private void retencionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion.Retencion.FrmTipoRetencion r = new Administracion.Retencion.FrmTipoRetencion();
            r.MdiParent = this;
            r.Show();
        }

        private void otroIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.Ingresos.FrmOtroIngreso o = new Ventas.Ingresos.FrmOtroIngreso();
            o.MdiParent = this;
            o.Show();
        }

        private void consultaOtroIgresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.Ingresos.FrmConsultaOtro co = new Ventas.Ingresos.FrmConsultaOtro();
            co.MdiParent = this;
            co.Show();
        }

        private void precioDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion.PrecioVenta.FrmPrecioVenta precio =
                new Configuracion.PrecioVenta.FrmPrecioVenta();
            precio.MdiParent = this;
            precio.Show();
        }

        private void ingresarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            /*Compras.Devolucion.FrmDevolucionCompra devolucionCompra =
                new Compras.Devolucion.FrmDevolucionCompra();
            devolucionCompra.MdiParent = this;
            devolucionCompra.Show();*/
        }

        private void inventariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion.Inventarios.FrmInventarios inv =
                new Configuracion.Inventarios.FrmInventarios();
            inv.MdiParent = this;
            inv.Show();
        }

        private void formasDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion.FormaPago.frmFormaPago fpago =
                new Configuracion.FormaPago.frmFormaPago();
            fpago.MdiParent = this;
            fpago.Show();
        }

        private void formatosDeImpresionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion.Formato.FrmFormatoPrint fPrint =
                new Configuracion.Formato.FrmFormatoPrint();
            fPrint.MdiParent = this;
            fPrint.Show();
        }

        Ventas.EditarPrecio.FrmPrecioProducto_ frmEdicionPrecioProducto = null;
        bool edicionPrecioProducto = false;

        private void editarPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (edicionPrecioProducto)
                frmEdicionPrecioProducto = null;
            try
            {
                Ventas.EditarPrecio.FrmPrecioProducto_ frmEdicionPrecioProducto1 =
                    (Ventas.EditarPrecio.FrmPrecioProducto_)this.ActiveMdiChild;
                if (frmEdicionPrecioProducto1 == null)
                {
                    frmEdicionPrecioProducto = new Ventas.EditarPrecio.FrmPrecioProducto_();
                    frmEdicionPrecioProducto.MdiParent = this;
                    frmEdicionPrecioProducto.Show();
                    edicionPrecioProducto = true;
                }
                else
                    edicionPrecioProducto = false;
            }
            catch
            {
                if (frmEdicionPrecioProducto == null)
                {
                    frmEdicionPrecioProducto = new Ventas.EditarPrecio.FrmPrecioProducto_();
                    frmEdicionPrecioProducto.MdiParent = this;
                    frmEdicionPrecioProducto.Show();
                    edicionPrecioProducto = true;
                }
                else
                    edicionPrecioProducto = false;
            }
            /* var frmEditarPrecio = new
                 Ventas.EditarPrecio.FrmPrecioProducto();
             frmEditarPrecio.MdiParent = this;
             frmEditarPrecio.Show();*/
        }

        private void configuracionEnVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmConfigVenta = new Aplicacion.Configuracion.Venta.FrmConfiguracionVenta();
            frmConfigVenta.MdiParent = this;
            frmConfigVenta.Show();
        }

        Inventario.SalidaEntrada.FrmAdminInventario salidaEntrada = null;
        private bool salEnt = false;

        private void entradaYSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*BussinesLayer.Clases.BussinesUsuario miBussinesUsuario =
                new BussinesLayer.Clases.BussinesUsuario();*/
            string rta = "";
            if (salEnt)
                salidaEntrada = null;
            try
            {
                Inventario.SalidaEntrada.FrmAdminInventario se =
                    (Inventario.SalidaEntrada.FrmAdminInventario)this.ActiveMdiChild;
                if (se == null)
                {
                    rta = CustomControl.OptionPane.OptionBox("Ingresar contraseña de Administrador .",
                        "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                    if (!rta.Equals("false"))
                    {
                        if (miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta)))
                        {
                            salidaEntrada = new Inventario.SalidaEntrada.FrmAdminInventario();
                            salidaEntrada.MdiParent = this;
                            salidaEntrada.Show();
                            salEnt = true;
                        }
                        else
                        {
                            CustomControl.OptionPane.MessageError("Contraseña incorrecta.");
                        }
                    }
                }
                else
                    salEnt = false;
            }
            catch
            {
                if (salidaEntrada == null)
                {
                    rta = CustomControl.OptionPane.OptionBox("Ingresar contraseña de Administrador .",
                        "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                    if (!rta.Equals("false"))
                    {
                        if (miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta)))
                        {
                            salidaEntrada = new Inventario.SalidaEntrada.FrmAdminInventario();
                            salidaEntrada.MdiParent = this;
                            salidaEntrada.Show();
                            salEnt = true;
                        }
                        else
                        {
                            CustomControl.OptionPane.MessageError("Contraseña incorrecta.");
                        }
                    }
                }
                else
                    salEnt = false;
            }
        }

        private void configuracionEnComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmConfigCompra = new Configuracion.Compra.FrmConfiguracion();
            frmConfigCompra.MdiParent = this;
            frmConfigCompra.Show();
        }

        private void carteraDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCartera = new Ventas.Cartera.FrmCartera();
            frmCartera.MdiParent = this;
            frmCartera.Show();
        }

        private void carteraDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCartera = new Compras.Cartera.FrmCartera();
            frmCartera.MdiParent = this;
            frmCartera.Show();
        }

        private void ingresarDevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dev_v)
                dev_venta = null;
            try
            {
                Ventas.Devolucion.Anterior.FrmDevolucionVenta ad =
                    (Ventas.Devolucion.Anterior.FrmDevolucionVenta)this.ActiveMdiChild;
                if (ad == null)
                {
                    dev_venta = new Ventas.Devolucion.Anterior.FrmDevolucionVenta();
                    dev_venta.Usuario_ = this.Usuario_;
                    dev_venta.MdiParent = this;
                    dev_venta.Show();
                    dev_v = true;
                }
                else
                    dev_v = false;
            }
            catch
            {
                if (dev_venta == null)
                {
                    dev_venta = new Ventas.Devolucion.Anterior.FrmDevolucionVenta();
                    dev_venta.Usuario_ = this.Usuario_;
                    dev_venta.MdiParent = this;
                    dev_venta.Show();
                    dev_v = true;
                }
                else
                    dev_v = false;
            }
        }

        private void consultarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var consultaeDevolucion = new Ventas.Devolucion.Anterior.FrmConsultaDevolucion();
            consultaeDevolucion.MdiParent = this;
            consultaeDevolucion.Show();
        }

        private void ingresarDevolucionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Compras.Devolucion.FrmDevolucionCompra devolucionCompra =
               new Compras.Devolucion.FrmDevolucionCompra();
            devolucionCompra.MdiParent = this;
            devolucionCompra.Show();
        }

        private void consultarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var consultaDevolucion = new Compras.Devolucion.FrmConsultaDevolucion();
            consultaDevolucion.MdiParent = this;
            consultaDevolucion.Show();
        }

        private void carteraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCarteraRemision = new Ventas.CarteraRemision.FrmCartera();
            frmCarteraRemision.MdiParent = this;
            frmCarteraRemision.Show();
        }

        private void ingresarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*var idBase = Utilities.AppConfiguracion.ValorSeccion("id_base");
            if (String.IsNullOrEmpty(idBase))
            {
                CustomControl.OptionPane.MessageInformation
                    ("Debe realizar apertura de caja para ingresar una Factura de Proveedor.");
            }
            else
            {*/
            if (comp)
                compra = null;
            try
            {
                Compras.IngresarCompra.FrmIngresarCompra c =
                    (Compras.IngresarCompra.FrmIngresarCompra)this.ActiveMdiChild;
                if (c == null)
                {
                    compra = new Compras.IngresarCompra.FrmIngresarCompra();
                    compra.MdiParent = this;
                    compra.Show();
                    comp = true;
                }
                else
                    comp = false;
            }
            catch
            {
                if (compra == null)
                {
                    compra = new Compras.IngresarCompra.FrmIngresarCompra();
                    compra.MdiParent = this;
                    compra.Show();
                    comp = true;
                }
                else
                    comp = false;
            }
            //}
        }

        private void consultarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (consc)
                consCompra = null;
            try
            {
                Compras.IngresarCompra.FrmConsulta c =
                    (Compras.IngresarCompra.FrmConsulta)this.ActiveMdiChild;
                if (c == null)
                {
                    consCompra = new Compras.IngresarCompra.FrmConsulta();
                    consCompra.MdiParent = this;
                    consCompra.Show();
                    consc = true;
                }
                else
                    consc = false;
            }
            catch
            {
                if (consCompra == null)
                {
                    consCompra = new Compras.IngresarCompra.FrmConsulta();
                    consCompra.MdiParent = this;
                    consCompra.Show();
                    consc = true;
                }
                else
                    consc = false;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmConsultaRemisionProveedor = new Compras.IngresarCompra.ConsultaRemision.FrmConsulta();
            frmConsultaRemisionProveedor.MdiParent = this;
            frmConsultaRemisionProveedor.Show();
        }

        private void carteraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmCarteraRemisionProveedor = new Compras.CarteraRemision.FrmCartera();
            frmCarteraRemisionProveedor.MdiParent = this;
            frmCarteraRemisionProveedor.Show();
        }

        Configuracion.Caja.FrmCaja confCaja = null;
        bool cfCaja = false;

        private void configuracionDeEstacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cfCaja)
                confCaja = null;
            try
            {
                Configuracion.Caja.FrmCaja configCaja =
                        (Configuracion.Caja.FrmCaja)this.ActiveMdiChild;
                if (configCaja == null)
                {
                    confCaja = new Configuracion.Caja.FrmCaja();
                    confCaja.MdiParent = this;
                    confCaja.Show();
                    cfCaja = true;
                }
                else
                    cfCaja = false;
            }
            catch
            {
                if (confCaja == null)
                {
                    confCaja = new Configuracion.Caja.FrmCaja();
                    confCaja.MdiParent = this;
                    confCaja.Show();
                    cfCaja = true;
                }
                else
                    cfCaja = false;
            }

            /**
            string rta = "";
            bool userAdmin = false;
            if (cfCaja)
                confCaja = null;
            try
            {
                try
                {
                    //miBussinesUsuario = new BussinesLayer.Clases.BussinesUsuario();
                    Configuracion.Caja.FrmCaja configCaja =
                        (Configuracion.Caja.FrmCaja)this.ActiveMdiChild;
                    if (configCaja == null)
                    {
                        while (!userAdmin)
                        {
                            rta = CustomControl.OptionPane.OptionBox
                            ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                            if (rta.Equals("false"))
                            {
                                break;
                            }
                            else
                            {
                                userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                if (userAdmin)
                                {
                                    confCaja = new Configuracion.Caja.FrmCaja();
                                    confCaja.MdiParent = this;
                                    confCaja.Show();
                                    cfCaja = true;
                                }
                            }
                        }
                        //confCaja = new Configuracion.Caja.FrmCaja();
                        //confCaja.MdiParent = this;
                        //confCaja.Show();
                        //cfCaja = true;
                    }
                    else
                    {
                        cfCaja = false;
                    }
                }
                catch
                {
                    if (confCaja == null)
                    {
                        while (!userAdmin)
                        {
                            rta = CustomControl.OptionPane.OptionBox
                            ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                            if (rta.Equals("false"))
                            {
                                break;
                            }
                            else
                            {
                                userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                if (userAdmin)
                                {
                                    confCaja = new Configuracion.Caja.FrmCaja();
                                    confCaja.MdiParent = this;
                                    confCaja.Show();
                                    cfCaja = true;
                                }
                            }
                        }
                        //confCaja = new Configuracion.Caja.FrmCaja();
                        //confCaja.MdiParent = this;
                        //confCaja.Show();
                        //cfCaja = true;
                    }
                    else
                        cfCaja = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            */
        }

        private void configuracionDeEstacionToolStripMenuItem_Click_(object sender, EventArgs e)
        {
            string rta = "";
            bool userAdmin = false;
            if (cfCaja)
                confCaja = null;
            try
            {
                try
                {
                    //miBussinesUsuario = new BussinesLayer.Clases.BussinesUsuario();
                    Configuracion.Caja.FrmCaja configCaja =
                        (Configuracion.Caja.FrmCaja)this.ActiveMdiChild;
                    if (configCaja == null)
                    {
                        while (!userAdmin)
                        {
                            rta = CustomControl.OptionPane.OptionBox
                            ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                            if (rta.Equals("false"))
                            {
                                break;
                            }
                            else
                            {
                                userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                if (userAdmin)
                                {
                                    confCaja = new Configuracion.Caja.FrmCaja();
                                    confCaja.MdiParent = this;
                                    confCaja.Show();
                                    cfCaja = true;
                                }
                            }
                        }
                        /*confCaja = new Configuracion.Caja.FrmCaja();
                        confCaja.MdiParent = this;
                        confCaja.Show();
                        cfCaja = true;*/
                    }
                    else
                    {
                        cfCaja = false;
                    }
                }
                catch
                {
                    if (confCaja == null)
                    {
                        while (!userAdmin)
                        {
                            rta = CustomControl.OptionPane.OptionBox
                            ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                            if (rta.Equals("false"))
                            {
                                break;
                            }
                            else
                            {
                                userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                if (userAdmin)
                                {
                                    confCaja = new Configuracion.Caja.FrmCaja();
                                    confCaja.MdiParent = this;
                                    confCaja.Show();
                                    cfCaja = true;
                                }
                            }
                        }
                        /*confCaja = new Configuracion.Caja.FrmCaja();
                        confCaja.MdiParent = this;
                        confCaja.Show();
                        cfCaja = true;*/
                    }
                    else
                        cfCaja = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        Administracion.Caja.FrCierreCaja cierreCaja = null;
        bool cierreCaja_ = false;
        private BussinesLayer.Clases.BussinesApertura miBussinesApertura;

        private void cierreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!miBussinesApertura.RegistrosApertura(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Rows.Count.Equals(0))  //
                {

                    //Application.OpenForms["FrmFacturaPos.cs"  FrmFacturaVenta.cs
                    /*foreach (Form forms_ in Application.OpenForms)
                    {
                        if (forms_.Text.Equals("Factura POS"))
                        {
                            var j = true;
                            forms_.Close();
                        }
                    }*/
                    //if(Application.OpenForms[""].Equals(

                    if (ValidaFormualrioAbierto("FrmFacturaPos") || ValidaFormualrioAbierto("FrmFacturaVenta") || ValidaFormualrioAbierto("FrmDevolucionVenta"))  //FrmDevolucionVenta
                    {
                        OptionPane.MessageInformation("Debe cerrar todos los formularios de venta y devolución.");
                    }
                    else
                    {
                        if (cierreCaja_)
                            cierreCaja = null;
                        try
                        {
                            Administracion.Caja.FrCierreCaja cierreCaja1 =
                                (Administracion.Caja.FrCierreCaja)this.ActiveMdiChild;
                            if (cierreCaja1 == null)
                            {
                                cierreCaja = new Administracion.Caja.FrCierreCaja();
                                cierreCaja.MdiParent = this;
                                cierreCaja.Show();
                                cierreCaja_ = true;
                            }
                            else
                                cierreCaja_ = false;
                        }
                        catch
                        {
                            if (cierreCaja == null)
                            {
                                cierreCaja = new Administracion.Caja.FrCierreCaja();
                                cierreCaja.MdiParent = this;
                                cierreCaja.Show();
                                cierreCaja_ = true;
                            }
                            else
                                cierreCaja_ = false;
                        }
                    }


                    /*string rta = "";
                    bool userAdmin = false;
                    if (cierreCaja_)
                        cierreCaja = null;
                    try
                    {
                        try
                        {
                            Administracion.Caja.FrCierreCaja ccaja =
                                (Administracion.Caja.FrCierreCaja)this.ActiveMdiChild;
                            if (ccaja == null)
                            {
                                while (!userAdmin)
                                {
                                    rta = CustomControl.OptionPane.OptionBox
                                        ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                                    if (rta.Equals("false"))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                        if (userAdmin)
                                        {
                                            cierreCaja = new Administracion.Caja.FrCierreCaja();
                                            cierreCaja.MdiParent = this;
                                            cierreCaja.Show();
                                            cierreCaja_ = true;
                                        }
                                    }
                                }
                            }
                            else
                                cierreCaja_ = false;
                        }
                        catch
                        {
                            if (cierreCaja == null)
                            {
                                while (!userAdmin)
                                {
                                    rta = CustomControl.OptionPane.OptionBox
                                        ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                                    if (rta.Equals("false"))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        userAdmin = miBussinesUsuario.VerificarUsuarioAdmin(Utilities.Encode.Encrypt(rta));
                                        if (userAdmin)
                                        {
                                            cierreCaja = new Administracion.Caja.FrCierreCaja();
                                            cierreCaja.MdiParent = this;
                                            cierreCaja.Show();
                                            cierreCaja_ = true;
                                        }
                                    }
                                }
                            }
                            else
                                cierreCaja_ = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }*/
                }
                else
                {
                    OptionPane.MessageError("La estación no presenta apertura de caja.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private bool ValidaFormualrioAbierto(string name)
        {
            bool isOpen = false;
            foreach (Form forms_ in Application.OpenForms)
            {
                if (forms_.Name.Equals(name))
                {
                    isOpen = true;
                }

                /*if (forms_.Text.Equals("Factura POS"))
                {
                    var j = true;
                    forms_.Close();
                }*/
            }
            return isOpen;
        }

        private void informacionDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmInforSystem = new Configuracion.Version.FrmVersion();
            frmInforSystem.ShowDialog();
        }


        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Compras.IngresarCompra.FrmConsultaCompras consultaCompra = null;
        bool consultaCompra_ = false;

        private void MenuComprasDeProducto_Click(object sender, EventArgs e)
        {
            if (consultaCompra_)
                consultaCompra = null;
            try
            {
                Compras.IngresarCompra.FrmConsultaCompras consultaCompra1 =
                    (Compras.IngresarCompra.FrmConsultaCompras)this.ActiveMdiChild;
                if (consultaCompra == null)
                {
                    consultaCompra = new Compras.IngresarCompra.FrmConsultaCompras();
                    consultaCompra.MdiParent = this;
                    consultaCompra.Show();
                    consultaCompra_ = true;
                }
                else
                    consultaCompra_ = false;
            }
            catch
            {
                if (consultaCompra == null)
                {
                    consultaCompra = new Compras.IngresarCompra.FrmConsultaCompras();
                    consultaCompra.MdiParent = this;
                    consultaCompra.Show();
                    consultaCompra_ = true;
                }
                else
                    consultaCompra_ = false;
            }
        }

        Compras.Beneficiario.FrmBeneficio frmTercero = null;
        bool tercero_ = false;

        private void MenuTerceros_Click(object sender, EventArgs e)
        {
            if (tercero_)
                frmTercero = null;
            try
            {
                Compras.Beneficiario.FrmBeneficio frmTercero1 =
                    (Compras.Beneficiario.FrmBeneficio)this.ActiveMdiChild;
                if (frmTercero1 == null)
                {
                    frmTercero = new Compras.Beneficiario.FrmBeneficio();
                    frmTercero.MdiParent = this;
                    frmTercero.Show();
                    tercero_ = true;
                }
                else
                    tercero_ = false;
            }
            catch
            {
                if (frmTercero == null)
                {
                    frmTercero = new Compras.Beneficiario.FrmBeneficio();
                    frmTercero.MdiParent = this;
                    frmTercero.Show();
                    tercero_ = true;
                }
                else
                    tercero_ = false;
            }
        }

        Compras.Anticipos.FrmAnticipo anticipo = null;
        bool anticipo_ = false;

        private void menuAnticipoIngresar_Click(object sender, EventArgs e)
        {
            if (anticipo_)
                anticipo = null;
            try
            {
                Compras.Anticipos.FrmAnticipo anticipo1 =
                    (Compras.Anticipos.FrmAnticipo)this.ActiveMdiChild;
                if (anticipo1 == null)
                {
                    anticipo = new Compras.Anticipos.FrmAnticipo();
                    anticipo.MdiParent = this;
                    anticipo.Show();
                    anticipo_ = true;
                }
                else
                    anticipo_ = false;
            }
            catch
            {
                if (anticipo == null)
                {
                    anticipo = new Compras.Anticipos.FrmAnticipo();
                    anticipo.MdiParent = this;
                    anticipo.Show();
                    anticipo_ = true;
                }
                else
                    anticipo_ = false;
            }
        }

        Compras.Anticipos.FrmConsultarAnticipos consultaAncitipo = null;
        bool consultaAncitipo_ = false;

        private void menuAnticipoConsultar_Click(object sender, EventArgs e)
        {
            if (consultaAncitipo_)
                consultaAncitipo = null;
            try
            {
                Compras.Anticipos.FrmConsultarAnticipos consultaAncitipo1 =
                    (Compras.Anticipos.FrmConsultarAnticipos)this.ActiveMdiChild;
                if (consultaAncitipo1 == null)
                {
                    consultaAncitipo = new Compras.Anticipos.FrmConsultarAnticipos();
                    consultaAncitipo.MdiParent = this;
                    consultaAncitipo.Show();
                    consultaAncitipo_ = true;
                }
                else
                    consultaAncitipo_ = false;
            }
            catch
            {
                if (consultaAncitipo == null)
                {
                    consultaAncitipo = new Compras.Anticipos.FrmConsultarAnticipos();
                    consultaAncitipo.MdiParent = this;
                    consultaAncitipo.Show();
                    consultaAncitipo_ = true;
                }
                else
                    consultaAncitipo_ = false;
            }
        }

        Compras.CuentasPorPagar.FrmCuentaPagar cuentaPagar = null;
        bool cuentaPagar_ = false;

        private void IngresarCuentaPorPagar_Click(object sender, EventArgs e)
        {
            if (cuentaPagar_)
                cuentaPagar = null;
            try
            {
                Compras.CuentasPorPagar.FrmCuentaPagar cuentaPagar1 =
                    (Compras.CuentasPorPagar.FrmCuentaPagar)this.ActiveMdiChild;
                if (cuentaPagar1 == null)
                {
                    cuentaPagar = new Compras.CuentasPorPagar.FrmCuentaPagar();
                    cuentaPagar.MdiParent = this;
                    cuentaPagar.Show();
                    cuentaPagar_ = true;
                }
                else
                    cuentaPagar_ = false;
            }
            catch
            {
                if (cuentaPagar == null)
                {
                    cuentaPagar = new Compras.CuentasPorPagar.FrmCuentaPagar();
                    cuentaPagar.MdiParent = this;
                    cuentaPagar.Show();
                    cuentaPagar_ = true;
                }
                else
                    cuentaPagar_ = false;
            }
        }

        Compras.CuentasPorPagar.FrmConsulta consultaCuentaPagar = null;
        bool consultaCuentaPagar_ = false;

        private void ConsultaCuentaPorPagar_Click(object sender, EventArgs e)
        {
            if (consultaCuentaPagar_)
                consultaCuentaPagar = null;
            try
            {
                Compras.CuentasPorPagar.FrmConsulta consultaCuentaPagar1 =
                    (Compras.CuentasPorPagar.FrmConsulta)this.ActiveMdiChild;
                if (consultaCuentaPagar1 == null)
                {
                    consultaCuentaPagar = new Compras.CuentasPorPagar.FrmConsulta();
                    consultaCuentaPagar.MdiParent = this;
                    consultaCuentaPagar.Show();
                    consultaCuentaPagar_ = true;
                }
                else
                    consultaCuentaPagar_ = false;
            }
            catch
            {
                if (consultaCuentaPagar == null)
                {
                    consultaCuentaPagar = new Compras.CuentasPorPagar.FrmConsulta();
                    consultaCuentaPagar.MdiParent = this;
                    consultaCuentaPagar.Show();
                    consultaCuentaPagar_ = true;
                }
                else
                    consultaCuentaPagar_ = false;
            }
        }

        private void resumneDeUtilidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        Ventas.EditarPrecio.FrmConsultaPrecio frmPrecio = null;
        bool frmPrecio_ = false;

        private void consultarPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmPrecio_)
                frmPrecio = null;
            try
            {
                Ventas.EditarPrecio.FrmConsultaPrecio frmPrecio1 =
                    (Ventas.EditarPrecio.FrmConsultaPrecio)this.ActiveMdiChild;
                if (frmPrecio1 == null)
                {
                    frmPrecio = new Ventas.EditarPrecio.FrmConsultaPrecio();
                    frmPrecio.MdiParent = this;
                    frmPrecio.Show();
                    frmPrecio_ = true;
                }
                else
                    frmPrecio_ = false;
            }
            catch
            {
                if (frmPrecio == null)
                {
                    frmPrecio = new Ventas.EditarPrecio.FrmConsultaPrecio();
                    frmPrecio.MdiParent = this;
                    frmPrecio.Show();
                    frmPrecio_ = true;
                }
                else
                    frmPrecio_ = false;
            }
        }

        Ventas.Devolucion.FrmCanjeArticulo frmCanje = null;
        bool canje = false;

        private void canjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (canje)
                frmCanje = null;
            try
            {
                Ventas.Devolucion.FrmCanjeArticulo frmCanje1 =
                    (Ventas.Devolucion.FrmCanjeArticulo)this.ActiveMdiChild;
                if (frmCanje1 == null)
                {
                    frmCanje = new Ventas.Devolucion.FrmCanjeArticulo();
                    frmCanje.MdiParent = this;
                    frmCanje.Show();
                    canje = true;
                }
                else
                    canje = false;
            }
            catch
            {
                if (frmCanje == null)
                {
                    frmCanje = new Ventas.Devolucion.FrmCanjeArticulo();
                    frmCanje.MdiParent = this;
                    frmCanje.Show();
                    canje = true;
                }
                else
                    canje = false;
            }
        }

        Administracion.Puc.FrmPuc frmPuc = null;
        bool puc_ = false;

        private void crearCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (puc_)
                frmPuc = null;
            try
            {
                Administracion.Puc.FrmPuc frmPuc1 =
                    (Administracion.Puc.FrmPuc)this.ActiveMdiChild;
                if (frmPuc1 == null)
                {
                    frmPuc = new Administracion.Puc.FrmPuc();
                    frmPuc.MdiParent = this;
                    frmPuc.Show();
                    puc_ = true;
                }
                else
                    puc_ = false;
            }
            catch
            {
                if (frmPuc == null)
                {
                    frmPuc = new Administracion.Puc.FrmPuc();
                    frmPuc.MdiParent = this;
                    frmPuc.Show();
                    puc_ = true;
                }
                else
                    puc_ = false;
            }
        }

        private Administracion.Puc.FrmConsultaPuc frmConsultaPuc = null;
        bool frmConsultaPuc_ = false;

        private void consultasToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (frmConsultaPuc_)
                frmConsultaPuc = null;
            try
            {
                Administracion.Puc.FrmConsultaPuc frmConsultaPuc1 =
                    (Administracion.Puc.FrmConsultaPuc)this.ActiveMdiChild;
                if (frmConsultaPuc1 == null)
                {
                    frmConsultaPuc = new Administracion.Puc.FrmConsultaPuc();
                    frmConsultaPuc.MdiParent = this;
                    frmConsultaPuc.Show();
                    frmConsultaPuc_ = true;
                }
                else
                    frmConsultaPuc_ = false;
            }
            catch
            {
                if (frmConsultaPuc == null)
                {
                    frmConsultaPuc = new Administracion.Puc.FrmConsultaPuc();
                    frmConsultaPuc.MdiParent = this;
                    frmConsultaPuc.Show();
                    frmConsultaPuc_ = true;
                }
                else
                    frmConsultaPuc_ = false;
            }
        }

        private Administracion.Iva.FrmAjuste frmAjusteIva = null;
        bool ajusteIva = false;

        private void ajustarIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ajusteIva)
                frmAjusteIva = null;
            try
            {
                Administracion.Iva.FrmAjuste frmAjusteIva1 =
                    (Administracion.Iva.FrmAjuste)this.ActiveMdiChild;
                if (frmAjusteIva1 == null)
                {
                    frmAjusteIva = new Administracion.Iva.FrmAjuste();
                    frmAjusteIva.MdiParent = this;
                    frmAjusteIva.Show();
                    ajusteIva = true;
                }
                else
                    ajusteIva = false;
            }
            catch
            {
                if (frmAjusteIva == null)
                {
                    frmAjusteIva = new Administracion.Iva.FrmAjuste();
                    frmAjusteIva.MdiParent = this;
                    frmAjusteIva.Show();
                    ajusteIva = true;
                }
                else
                    ajusteIva = false;
            }
        }


        
        ///private Compras.IngresarCompra.FrmPreIngresoCompra frmPreIngreso = null;
        private Compras.PreIngreso.FrmPreIngresoCompra frmPreIngreso = null;
        bool preIngreso = false;

        private void ingresarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (preIngreso)
                frmPreIngreso = null;
            try
            {
                Compras.PreIngreso.FrmPreIngresoCompra frmPreIngreso1 =
                    (Compras.PreIngreso.FrmPreIngresoCompra)this.ActiveMdiChild;
                if (frmPreIngreso1 == null)
                {
                    frmPreIngreso = new Compras.PreIngreso.FrmPreIngresoCompra();
                    frmPreIngreso.MdiParent = this;
                    frmPreIngreso.Show();
                    preIngreso = true;
                }
                else
                    preIngreso = false;
            }
            catch
            {
                if (frmPreIngreso == null)
                {
                    frmPreIngreso = new Compras.PreIngreso.FrmPreIngresoCompra();
                    frmPreIngreso.MdiParent = this;
                    frmPreIngreso.Show();
                    preIngreso = true;
                }
                else
                    preIngreso = false;
            }
        }

        ///private Compras.IngresarCompra.FrmConsultaPreIngreso frmConsultaPreIngreso = null;
        private Compras.PreIngreso.FrmConsultaPreIngreso frmConsultaPreIngreso = null;
        bool consultaPreIngreso = false;

        private void consultarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (consultaPreIngreso)
                frmConsultaPreIngreso = null;
            try
            {
                Compras.PreIngreso.FrmConsultaPreIngreso frmConsultaPreIngreso1 =
                    (Compras.PreIngreso.FrmConsultaPreIngreso)this.ActiveMdiChild;
                if (frmConsultaPreIngreso1 == null)
                {
                    frmConsultaPreIngreso = new Compras.PreIngreso.FrmConsultaPreIngreso();
                    frmConsultaPreIngreso.MdiParent = this;
                    frmConsultaPreIngreso.Show();
                    consultaPreIngreso = true;
                }
                else
                    consultaPreIngreso = false;
            }
            catch
            {
                if (frmConsultaPreIngreso == null)
                {
                    frmConsultaPreIngreso = new Compras.PreIngreso.FrmConsultaPreIngreso();
                    frmConsultaPreIngreso.MdiParent = this;
                    frmConsultaPreIngreso.Show();
                    consultaPreIngreso = true;
                }
                else
                    consultaPreIngreso = false;
            }
        }

        Ventas.Cliente.Anticipos.FrmNuevo anticipoCliente = null;
        bool anticipoCliente_ = false;

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (anticipoCliente_)
                anticipoCliente = null;
            try
            {
                Ventas.Cliente.Anticipos.FrmNuevo ad =
                    (Ventas.Cliente.Anticipos.FrmNuevo)this.ActiveMdiChild;
                if (ad == null)
                {
                    anticipoCliente = new Ventas.Cliente.Anticipos.FrmNuevo();
                    anticipoCliente.MdiParent = this;
                    anticipoCliente.Show();
                    anticipoCliente_ = true;
                }
                else
                    anticipoCliente_ = false;
            }
            catch
            {
                if (anticipoCliente == null)
                {
                    anticipoCliente = new Ventas.Cliente.Anticipos.FrmNuevo();
                    anticipoCliente.MdiParent = this;
                    anticipoCliente.Show();
                    anticipoCliente_ = true;
                }
                else
                    anticipoCliente_ = false;
            }
        }

        Ventas.Cliente.Anticipos.FrmAnticipo consultaAnticipoCliente = null;
        bool consultaAnticipoCliente_ = false;

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (consultaAnticipoCliente_)
                consultaAnticipoCliente = null;
            try
            {
                Ventas.Cliente.Anticipos.FrmAnticipo ad =
                    (Ventas.Cliente.Anticipos.FrmAnticipo)this.ActiveMdiChild;
                if (ad == null)
                {
                    consultaAnticipoCliente = new Ventas.Cliente.Anticipos.FrmAnticipo();
                    consultaAnticipoCliente.MdiParent = this;
                    consultaAnticipoCliente.Show();
                    consultaAnticipoCliente_ = true;
                }
                else
                    consultaAnticipoCliente_ = false;
            }
            catch
            {
                if (consultaAnticipoCliente == null)
                {
                    consultaAnticipoCliente = new Ventas.Cliente.Anticipos.FrmAnticipo();
                    consultaAnticipoCliente.MdiParent = this;
                    consultaAnticipoCliente.Show();
                    consultaAnticipoCliente_ = true;
                }
                else
                    consultaAnticipoCliente_ = false;
            }
        }

        Configuracion.Backup.FrmBackup backup = null;
        bool backup_ = false;

        private void copiasDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backup_)
                backup = null;
            try
            {
                Configuracion.Backup.FrmBackup backup1 =
                    (Configuracion.Backup.FrmBackup)this.ActiveMdiChild;
                if (backup1 == null)
                {
                    backup = new Configuracion.Backup.FrmBackup();
                    backup.MdiParent = this;
                    backup.Show();
                    backup_ = true;
                }
                else
                    backup_ = false;
            }
            catch
            {
                if (backup == null)
                {
                    backup = new Configuracion.Backup.FrmBackup();
                    backup.MdiParent = this;
                    backup.Show();
                    backup_ = true;
                }
                else
                    backup_ = false;
            }
        }

        Inventario.Kardex.FrmKardex frmKardex = null;
        bool k = false;
        private void consultaKardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (k)
                frmKardex = null;
            try
            {
                Inventario.Kardex.FrmKardex frmKardex_ =
                    (Inventario.Kardex.FrmKardex)this.ActiveMdiChild;
                if (frmKardex_ == null)
                {
                    frmKardex = new Inventario.Kardex.FrmKardex();
                    frmKardex.MdiParent = this;
                    frmKardex.Show();
                    k = true;
                }
                else
                    k = false;
            }
            catch
            {
                if (frmKardex == null)
                {
                    frmKardex = new Inventario.Kardex.FrmKardex();
                    frmKardex.MdiParent = this;
                    frmKardex.Show();
                    k = true;
                }
                else
                    k = false;
            }
        }

        Inventario.Kardex.FrmConsultaProductos productosVendidosBajoPrecio = null;
        bool productosVendidosBajoPrecio_ = false;
        private void consultaProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productosVendidosBajoPrecio_)
                productosVendidosBajoPrecio = null;
            try
            {
                Inventario.Kardex.FrmConsultaProductos productosVendidosBajoPrecio1 =
                    (Inventario.Kardex.FrmConsultaProductos)this.ActiveMdiChild;
                if (productosVendidosBajoPrecio1 == null)
                {
                    productosVendidosBajoPrecio = new Inventario.Kardex.FrmConsultaProductos();
                    productosVendidosBajoPrecio.MdiParent = this;
                    productosVendidosBajoPrecio.Show();
                    productosVendidosBajoPrecio_ = true;
                }
                else
                    productosVendidosBajoPrecio_ = false;
            }
            catch
            {
                if (productosVendidosBajoPrecio == null)
                {
                    productosVendidosBajoPrecio = new Inventario.Kardex.FrmConsultaProductos();
                    productosVendidosBajoPrecio.MdiParent = this;
                    productosVendidosBajoPrecio.Show();
                    productosVendidosBajoPrecio_ = true;
                }
                else
                    productosVendidosBajoPrecio_ = false;
            }
        }



        Ventas.Factura.FrmResumenVenta resumenVenta = null;
        bool resumenVenta_ = false;

        Ventas.Consultas.FrmConsultaImpVenta frmConsultaImpVenta = null;
        bool FrmConsultaImpVenta_ = false;
        private void resumenDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /**if (resumenVenta_)
                resumenVenta = null;
            try
            {
                Ventas.Factura.FrmResumenVenta resumenVenta1 =
                    (Ventas.Factura.FrmResumenVenta)this.ActiveMdiChild;
                if (resumenVenta1 == null)
                {
                    resumenVenta = new Ventas.Factura.FrmResumenVenta();
                    resumenVenta.MdiParent = this;
                    resumenVenta.Show();
                    resumenVenta_ = true;
                }
                else
                    resumenVenta_ = false;
            }
            catch
            {
                if (resumenVenta == null)
                {
                    resumenVenta = new Ventas.Factura.FrmResumenVenta();
                    resumenVenta.MdiParent = this;
                    resumenVenta.Show();
                    resumenVenta_ = true;
                }
                else
                    resumenVenta_ = false;
            }*/

            if (FrmConsultaImpVenta_)
                frmConsultaImpVenta = null;
            try
            {
                Ventas.Consultas.FrmConsultaImpVenta resumenVenta1 =
                    (Ventas.Consultas.FrmConsultaImpVenta)this.ActiveMdiChild;
                if (resumenVenta1 == null)
                {
                    frmConsultaImpVenta = new Ventas.Consultas.FrmConsultaImpVenta();
                    frmConsultaImpVenta.MdiParent = this;
                    frmConsultaImpVenta.Show();
                    FrmConsultaImpVenta_ = true;
                }
                else
                    FrmConsultaImpVenta_ = false;
            }
            catch
            {
                if (resumenVenta == null)
                {
                    frmConsultaImpVenta = new Ventas.Consultas.FrmConsultaImpVenta();
                    frmConsultaImpVenta.MdiParent = this;
                    frmConsultaImpVenta.Show();
                    FrmConsultaImpVenta_ = true;
                }
                else
                    FrmConsultaImpVenta_ = false;
            }
        }

        Ventas.Factura.FrmResumenVentaCategoria resumenVentaCategoria = null;
        bool resumenVentaCategoria_ = false;
        private void resumenDeVentasPorCategoríaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resumenVentaCategoria_)
                resumenVentaCategoria = null;
            try
            {
                Ventas.Factura.FrmResumenVentaCategoria resumenVentaCategoria1 =
                    (Ventas.Factura.FrmResumenVentaCategoria)this.ActiveMdiChild;
                if (resumenVentaCategoria1 == null)
                {
                    resumenVentaCategoria = new Ventas.Factura.FrmResumenVentaCategoria();
                    resumenVentaCategoria.MdiParent = this;
                    resumenVentaCategoria.Show();
                    resumenVentaCategoria_ = true;
                }
                else
                    resumenVentaCategoria_ = false;
            }
            catch
            {
                if (resumenVentaCategoria == null)
                {
                    resumenVentaCategoria = new Ventas.Factura.FrmResumenVentaCategoria();
                    resumenVentaCategoria.MdiParent = this;
                    resumenVentaCategoria.Show();
                    resumenVentaCategoria_ = true;
                }
                else
                    resumenVentaCategoria_ = false;
            }
        }

        Compras.IngresarCompra.FrmCompraSimple frmCompraSimple = null;
        bool frmCompraSimple_ = false;

        private void ingresarComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCompraSimple_)
                frmCompraSimple = null;
            try
            {
                Compras.IngresarCompra.FrmCompraSimple frmCompraSimple1 =
                    (Compras.IngresarCompra.FrmCompraSimple)this.ActiveMdiChild;
                if (frmCompraSimple1 == null)
                {
                    frmCompraSimple = new Compras.IngresarCompra.FrmCompraSimple();
                    frmCompraSimple.MdiParent = this;
                    frmCompraSimple.Show();
                    frmCompraSimple.ColorearGridProducto();
                    frmCompraSimple.ColorearGridDescuento();
                    frmCompraSimple_ = true;
                }
                else
                    frmCompraSimple_ = false;
            }
            catch
            {
                if (frmCompraSimple == null)
                {
                    frmCompraSimple = new Compras.IngresarCompra.FrmCompraSimple();
                    frmCompraSimple.MdiParent = this;
                    frmCompraSimple.Show();
                    frmCompraSimple.ColorearGridProducto();
                    frmCompraSimple.ColorearGridDescuento();
                    frmCompraSimple_ = true;
                }
                else
                    frmCompraSimple_ = false;
            }
        }

        Compras.IngresarCompra.FrmConsultaCompraSimple frmConsultaCompraSimple = null;
        bool frmConsultaCompraSimple_ = false;

        private void consultarComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmConsultaCompraSimple_)
                frmConsultaCompraSimple = null;
            try
            {
                Compras.IngresarCompra.FrmConsultaCompraSimple frmConsultaCompraSimple1 =
                    (Compras.IngresarCompra.FrmConsultaCompraSimple)this.ActiveMdiChild;
                if (frmConsultaCompraSimple1 == null)
                {
                    frmConsultaCompraSimple = new Compras.IngresarCompra.FrmConsultaCompraSimple();
                    frmConsultaCompraSimple.MdiParent = this;
                    frmConsultaCompraSimple.Show();
                    frmConsultaCompraSimple_ = true;
                }
                else
                    frmConsultaCompraSimple_ = false;
            }
            catch
            {
                if (frmConsultaCompraSimple == null)
                {
                    frmConsultaCompraSimple = new Compras.IngresarCompra.FrmConsultaCompraSimple();
                    frmConsultaCompraSimple.MdiParent = this;
                    frmConsultaCompraSimple.Show();
                    frmConsultaCompraSimple_ = true;
                }
                else
                    frmConsultaCompraSimple_ = false;
            }
        }


        Ventas.Consultas.FrmConsultaComprasContable frmConsultaContCompras = null;
        bool frmConsultaContCompras_ = false;

        private void contableComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmConsultaContCompras_)
                frmConsultaContCompras = null;
            try
            {
                Ventas.Consultas.FrmConsultaComprasContable frmConsultaContCompras1 =
                    (Ventas.Consultas.FrmConsultaComprasContable)this.ActiveMdiChild;
                if (frmConsultaContCompras1 == null)
                {
                    frmConsultaContCompras = new Ventas.Consultas.FrmConsultaComprasContable();
                    frmConsultaContCompras.MdiParent = this;
                    frmConsultaContCompras.Show();
                    frmConsultaContCompras_ = true;
                }
                else
                    frmConsultaContCompras_ = false;
            }
            catch
            {
                if (frmConsultaContCompras == null)
                {
                    frmConsultaContCompras = new Ventas.Consultas.FrmConsultaComprasContable();
                    frmConsultaContCompras.MdiParent = this;
                    frmConsultaContCompras.Show();
                    frmConsultaContCompras_ = true;
                }
                else
                    frmConsultaContCompras_ = false;
            }
        }

        Administracion.Usuario.frmUsuarioSistema frmUsuarioSistema = null;
        bool frmUsuarioSistema_ = false;

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            if (frmUsuarioSistema_)
                frmUsuarioSistema = null;
            try
            {
                Administracion.Usuario.frmUsuarioSistema frmUsuarioSistema1 =
                    (Administracion.Usuario.frmUsuarioSistema)this.ActiveMdiChild;
                if (frmUsuarioSistema1 == null)
                {
                    frmUsuarioSistema = new Administracion.Usuario.frmUsuarioSistema();
                    frmUsuarioSistema.MdiParent = this;
                    frmUsuarioSistema.Show();
                    frmUsuarioSistema_ = true;
                }
                else
                    frmUsuarioSistema_ = false;
            }
            catch
            {
                if (frmUsuarioSistema == null)
                {
                    frmUsuarioSistema = new Administracion.Usuario.frmUsuarioSistema();
                    frmUsuarioSistema.MdiParent = this;
                    frmUsuarioSistema.Show();
                    frmUsuarioSistema_ = true;
                }
                else
                    frmUsuarioSistema_ = false;
            }
        }

        private void menuCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show
                ("¿Esta seguro(a) de querer cerrar la sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                int CountForms = Application.OpenForms.Count - 1;
                for (int i = CountForms; i > 0; i--)
                {
                    if (Application.OpenForms[i] != this)
                    {
                        Application.OpenForms[i].Close();
                    }
                }
                DeshabilitarMenu();
                var frmAcceso = new Administracion.Usuario.FrmAcceso();
                frmAcceso.MdiParent = this;
                frmAcceso.Show();
            }
        }

        private Ventas.Consultas.FrmConsultaVentaProductos frmConsultaVentaProductos = null;
        private bool frmConsultaVentaProductos_ = false;

        private void MenuConsultaVentaDeProductos_Click(object sender, EventArgs e)
        {
            if (frmConsultaVentaProductos_)
                frmConsultaVentaProductos = null;
            try
            {
                Ventas.Consultas.FrmConsultaVentaProductos frmConsultaVentaProductos1 =
                    (Ventas.Consultas.FrmConsultaVentaProductos)this.ActiveMdiChild;
                if (frmConsultaVentaProductos1 == null)
                {
                    frmConsultaVentaProductos = new Ventas.Consultas.FrmConsultaVentaProductos();
                    frmConsultaVentaProductos.MdiParent = this;
                    frmConsultaVentaProductos.Show();
                    frmConsultaVentaProductos_ = true;
                }
                else
                    frmConsultaVentaProductos_ = false;
            }
            catch
            {
                if (frmConsultaVentaProductos == null)
                {
                    frmConsultaVentaProductos = new Ventas.Consultas.FrmConsultaVentaProductos();
                    frmConsultaVentaProductos.MdiParent = this;
                    frmConsultaVentaProductos.Show();
                    frmConsultaVentaProductos_ = true;
                }
                else
                    frmConsultaVentaProductos_ = false;
            }
        }

        private Inventario.Conversion.FrmConfConversion frmConfConversion = null;
        private bool ConfConversion = false;

        private void tsMenuConfiguracion_Click(object sender, EventArgs e)
        {
            if (ConfConversion)
                frmConfConversion = null;
            try
            {
                Inventario.Conversion.FrmConfConversion frmConfConversion1 =
                    (Inventario.Conversion.FrmConfConversion)this.ActiveMdiChild;
                if (frmConfConversion1 == null)
                {
                    frmConfConversion = new Inventario.Conversion.FrmConfConversion();
                    frmConfConversion.MdiParent = this;
                    frmConfConversion.Show();
                    ConfConversion = true;
                }
                else
                    ConfConversion = false;
            }
            catch
            {
                if (frmConfConversion == null)
                {
                    frmConfConversion = new Inventario.Conversion.FrmConfConversion();
                    frmConfConversion.MdiParent = this;
                    frmConfConversion.Show();
                    ConfConversion = true;
                }
                else
                    ConfConversion = false;
            }
        }

        private Inventario.Conversion.FrmConversion frmConversion = null;
        private bool conversion = false;

        private void tsMenuConvertir_Click(object sender, EventArgs e)
        {
            if (conversion)
                frmConversion = null;
            try
            {
                Inventario.Conversion.FrmConversion frmConversion1 =
                    (Inventario.Conversion.FrmConversion)this.ActiveMdiChild;
                if (frmConversion1 == null)
                {
                    frmConversion = new Inventario.Conversion.FrmConversion();
                    frmConversion.MdiParent = this;
                    frmConversion.Show();
                    conversion = true;
                }
                else
                    conversion = false;
            }
            catch
            {
                if (frmConversion == null)
                {
                    frmConversion = new Inventario.Conversion.FrmConversion();
                    frmConversion.MdiParent = this;
                    frmConversion.Show();
                    conversion = true;
                }
                else
                    conversion = false;
            }
        }

        private void DeshabilitarMenu()
        {
            this.menuConfiguracion.Enabled = false;
            this.menuAdministrar.Enabled = false;
            this.menuInventario.Enabled = false;
            this.entradaYSalidaInventario.Enabled = false;
            this.MenuTerceros.Enabled = false;
            this.sbProveedor.Enabled = false;
            this.ingresarPreIngreso.Enabled = false;
            this.consultarPreIngreso.Enabled = false;
            this.ingresarFacturaProveedor.Enabled = false;
            this.consultarFacturaProveedor.Enabled = false;
            this.menuConsultarRemisionCompra.Enabled = false;
            this.carteraRemisionCompra.Enabled = false;
            this.menuIngresarEgreso.Enabled = false;
            this.menuConsultaEgreso.Enabled = false;
            this.ingresarDevolucionCompra.Enabled = false;
            this.consultarDevolucionCompra.Enabled = false;
            this.carteraDeProveedores.Enabled = false;

            this.menuCliente.Enabled = false;
            this.menuNuevoAnticipoCliente.Enabled = false;
            this.menuConsultaAnticipoCliente.Enabled = false;
            this.menuAperturaCaja.Enabled = false;
            this.menuCierreCaja.Enabled = false;
            this.menuConsultaCaja.Enabled = false;
            this.menuEditarPrecioProd.Enabled = false;
            this.menuConsultarPrecio.Enabled = false;
            this.menuFacturarVenta.Enabled = false;
            this.menuFacturarPos.Enabled = false;
            this.menuConsultarVentas.Enabled = false;
            this.menuRemisionVenta.Enabled = false;
            this.menuRemisionPos.Enabled = false;
            this.menuConsultaRemisionVenta.Enabled = false;
            this.menuCarteraRemVenta.Enabled = false;
            this.menuIngresarDevolucionVenta.Enabled = false;
            this.menuConsultaDevolVenta.Enabled = false;
            this.menuIngDevolRemVenta.Enabled = false;
            this.menuCanjeProducto.Enabled = false;
            this.menuOtroIngreso.Enabled = false;
            this.menuConsultaOtroIngreso.Enabled = false;
            this.menuConsultaIngresos.Enabled = false;
            this.menuCarteraDeClientes.Enabled = false;
            this.menuReporteCajaDiario.Enabled = false;
            this.menuResumenDeVentas.Enabled = false;
            this.menuResumenDeVentasPorCategoria.Enabled = false;

            this.menuTesoreria.Enabled = false;
            this.menuCerrarSesion.Enabled = false;
            this.sbMenuCompraDevolucion.Enabled = false;
            this.menuDevolucionProveedor.Enabled = false;
            this.menuPreingreso.Enabled = false;
            this.sbIngresarCompra.Enabled = false;
            this.menuRemisionesCompra.Enabled = false;
            this.menuEgresos.Enabled = false;

            this.sbMenuAnticiposCliente.Enabled = false;
            this.sbMenuVentaDevolucion.Enabled = false;
            this.sbMenuClientes.Enabled = false;
            this.menuCaja.Enabled = false;
            this.menuFacturarVentas.Enabled = false;
            this.menuRemisionesVenta.Enabled = false;
            this.menuDevolucionVenta.Enabled = false;
            this.menuIngresos.Enabled = false;
            this.menuResumneDeUtilidades.Enabled = false;
            this.menuCompras.Enabled = false;
            this.menuVentas.Enabled = false;

            this.sistemaToolStripMenuItem.Enabled = false;
        }

        private Ventas.Descuentos.FrmDescuentosPorMarca frmDescuentosPorMarca;
        private bool DescuentosPorMarca = false;

        private void menuDescuentosPorMarcas_Click(object sender, EventArgs e)
        {
            if (DescuentosPorMarca)
                frmDescuentosPorMarca = null;
            try
            {
                Ventas.Descuentos.FrmDescuentosPorMarca frmDescuentosPorMarca1 =
                    (Ventas.Descuentos.FrmDescuentosPorMarca)this.ActiveMdiChild;
                if (frmDescuentosPorMarca1 == null)
                {
                    frmDescuentosPorMarca = new Ventas.Descuentos.FrmDescuentosPorMarca();
                    frmDescuentosPorMarca.MdiParent = this;
                    frmDescuentosPorMarca.Show();
                    DescuentosPorMarca = true;
                }
                else
                    DescuentosPorMarca = false;
            }
            catch
            {
                if (frmDescuentosPorMarca == null)
                {
                    frmDescuentosPorMarca = new Ventas.Descuentos.FrmDescuentosPorMarca();
                    frmDescuentosPorMarca.MdiParent = this;
                    frmDescuentosPorMarca.Show();
                    DescuentosPorMarca = true;
                }
                else
                    DescuentosPorMarca = false;
            }
        }

        Administracion.Puntos.frmPuntos formPuntos;
        bool formPuntos_ = false;

        private void puntosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formPuntos_)
                formPuntos = null;
            try
            {
                Administracion.Puntos.frmPuntos formPuntos1 =
                    (Administracion.Puntos.frmPuntos)this.ActiveMdiChild;
                if (formPuntos1 == null)
                {
                    formPuntos = new Administracion.Puntos.frmPuntos();
                    formPuntos.MdiParent = this;
                    formPuntos.Show();
                    formPuntos_ = true;
                }
                else
                    formPuntos_ = false;
            }
            catch
            {
                if (formPuntos == null)
                {
                    formPuntos = new Administracion.Puntos.frmPuntos();
                    formPuntos.MdiParent = this;
                    formPuntos.Show();
                    formPuntos_ = true;
                }
                else
                    formPuntos_ = false;
            }
        }

        Administracion.Bonos.FrmBonos formBonos;
        bool formBonos_ = false;

        private void bonosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (formBonos_)
                formBonos = null;
            try
            {
                Administracion.Bonos.FrmBonos formBonos1 =
                    (Administracion.Bonos.FrmBonos)this.ActiveMdiChild;
                if (formBonos1 == null)
                {
                    formBonos = new Administracion.Bonos.FrmBonos();
                    formBonos.MdiParent = this;
                    formBonos.Show();
                    formBonos_ = true;
                }
                else
                    formBonos_ = false;
            }
            catch
            {
                if (formBonos == null)
                {
                    formBonos = new Administracion.Bonos.FrmBonos();
                    formBonos.MdiParent = this;
                    formBonos.Show();
                    formBonos_ = true;
                }
                else
                    formBonos_ = false;
            }
        }


        Inventario.Kardex.FrmConstruirInventario frmConstruirInventario;
        bool frmConstruirInventario_ = false;

        private void consultaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (frmConstruirInventario_)
                frmConstruirInventario = null;
            try
            {
                Inventario.Kardex.FrmConstruirInventario frmConstruirInventario1 =
                    (Inventario.Kardex.FrmConstruirInventario)this.ActiveMdiChild;
                if (frmConstruirInventario1 == null)
                {
                    frmConstruirInventario = new Inventario.Kardex.FrmConstruirInventario();
                    frmConstruirInventario.MdiParent = this;
                    frmConstruirInventario.Show();
                    frmConstruirInventario_ = true;
                }
                else
                    frmConstruirInventario_ = false;
            }
            catch
            {
                if (frmConstruirInventario == null)
                {
                    frmConstruirInventario = new Inventario.Kardex.FrmConstruirInventario();
                    frmConstruirInventario.MdiParent = this;
                    frmConstruirInventario.Show();
                    frmConstruirInventario_ = true;
                }
                else
                    frmConstruirInventario_ = false;
            }
        }


        Ventas.Consultas.FrmConsultaVentaProductosClasificacion frmConsultaVentaProductosClasificacion;
        bool frmConsultaVentaProductosClasificacion_ = false;

        private void resumenDeVentasPorClilenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmConsultaVentaProductosClasificacion_)
                frmConsultaVentaProductosClasificacion = null;
            try
            {
                Ventas.Consultas.FrmConsultaVentaProductosClasificacion frmConsultaVentaProductosClasificacion1 =
                    (Ventas.Consultas.FrmConsultaVentaProductosClasificacion)this.ActiveMdiChild;
                if (frmConsultaVentaProductosClasificacion1 == null)
                {
                    frmConsultaVentaProductosClasificacion = new Ventas.Consultas.FrmConsultaVentaProductosClasificacion();
                    frmConsultaVentaProductosClasificacion.MdiParent = this;
                    frmConsultaVentaProductosClasificacion.Show();
                    frmConsultaVentaProductosClasificacion_ = true;
                }
                else
                    frmConsultaVentaProductosClasificacion_ = false;
            }
            catch
            {
                if (frmConsultaVentaProductosClasificacion == null)
                {
                    frmConsultaVentaProductosClasificacion = new Ventas.Consultas.FrmConsultaVentaProductosClasificacion();
                    frmConsultaVentaProductosClasificacion.MdiParent = this;
                    frmConsultaVentaProductosClasificacion.Show();
                    frmConsultaVentaProductosClasificacion_ = true;
                }
                else
                    frmConsultaVentaProductosClasificacion_ = false;
            }
        }

        Inventario.Traslado.FrmTraslado frmTraslado;
        bool frmTraslado_ = false;

        private void trasladoDeInventariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTraslado_)
                frmTraslado = null;
            try
            {
                Inventario.Traslado.FrmTraslado frmTraslado1 =
                    (Inventario.Traslado.FrmTraslado)this.ActiveMdiChild;
                if (frmTraslado1 == null)
                {
                    frmTraslado = new Inventario.Traslado.FrmTraslado();
                    frmTraslado.MdiParent = this;
                    frmTraslado.Show();
                    frmTraslado_ = true;
                }
                else
                    frmTraslado_ = false;
            }
            catch
            {
                if (frmTraslado == null)
                {
                    frmTraslado = new Inventario.Traslado.FrmTraslado();
                    frmTraslado.MdiParent = this;
                    frmTraslado.Show();
                    frmTraslado_ = true;
                }
                else
                    frmTraslado_ = false;
            }
        }

        Inventario.ProductoFabricado.FrmProductoFabricado frmProductoFabricado;
        bool frmProductoFabricado_ = false;

        private void productosFabricadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmProductoFabricado_)
                frmProductoFabricado = null;
            try
            {
                Inventario.ProductoFabricado.FrmProductoFabricado frmProductoFabricado1 =
                    (Inventario.ProductoFabricado.FrmProductoFabricado)this.ActiveMdiChild;
                if (frmProductoFabricado1 == null)
                {
                    frmProductoFabricado = new Inventario.ProductoFabricado.FrmProductoFabricado();
                    frmProductoFabricado.MdiParent = this;
                    frmProductoFabricado.Show();
                    frmProductoFabricado_ = true;
                }
                else
                    frmProductoFabricado_ = false;
            }
            catch
            {
                if (frmProductoFabricado == null)
                {
                    frmProductoFabricado = new Inventario.ProductoFabricado.FrmProductoFabricado();
                    frmProductoFabricado.MdiParent = this;
                    frmProductoFabricado.Show();
                    frmProductoFabricado_ = true;
                }
                else
                    frmProductoFabricado_ = false;
            }
        }

        private void facturaElectronicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmDE = new FormulariosSistema.FrmElectronicDocument();
            frmDE.MdiParent = this;
            frmDE.txtProductCode.Focus();
            frmDE.Show();
        }

        private void consultaFEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmDE = new FormulariosSistema.FrmListDE();
            frmDE.MdiParent = this;
            frmDE.Show();
            frmDE.LoadColorGrid();
        }

        private void configEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmEmpresa = new FormulariosSistema.FrmCompany();
            frmEmpresa.MdiParent = this;
            frmEmpresa.Show();
            
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCliente = new FormulariosSistema.FrmCustomer();
            frmCliente.MdiParent = this;
            frmCliente.Show();
        }

        

    }
}