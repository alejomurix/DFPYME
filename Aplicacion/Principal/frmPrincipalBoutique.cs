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
    public partial class frmPrincipalBoutique : Form
    {
        private bool CargaCliente { set; get; }

        private BussinesLayer.Clases.BussinesUsuario miBussinesUsuario;

        private BussinesLayer.Clases.BussinesDian miBussinesDian;

        public frmPrincipalBoutique()
        {
            //miBussinesUsuario = new BussinesLayer.Clases.BussinesUsuario();
            miBussinesApertura = new BussinesLayer.Clases.BussinesApertura();
            InitializeComponent();
            try
            {
                miBussinesUsuario = new BussinesLayer.Clases.BussinesUsuario();
                CargaCliente = Convert.ToBoolean(AppConfiguracion.ValorSeccion("cargarCliente"));
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
                HabilitarMenu();
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

        private void sbMenuClientes_Click(object sender, EventArgs e)
        {

        }

        private void consultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        Inventario.Consulta.FrmConsultaInventario invCons = null;
        bool invc = false;

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
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

        Ventas.Factura.FrmFacturaVenta ventaPOS = null;
        bool vPOS = false;
        // pos
        private void facturaPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(AppConfiguracion.ValorSeccion("id_caja")))
            {
                try
                {
                    miBussinesDian = new BussinesLayer.Clases.BussinesDian();
                    var execute = false;
                    if (miBussinesDian.ConsultaDian().Rows.Count != 0)
                    {
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

                        if (execute)
                        {
                            //frm ventaPOS
                            //bool vPOS
                            if (vPOS)
                                ventaPOS = null;
                            try
                            {
                                Ventas.Factura.FrmFacturaVenta ve_ =
                                    (Ventas.Factura.FrmFacturaVenta)this.ActiveMdiChild;
                                if (ve_ == null)
                                {
                                    ventaPOS = new Ventas.Factura.FrmFacturaVenta();
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
                                    ventaPOS = new Ventas.Factura.FrmFacturaVenta();
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
                this.marcasToolStripMenuItem.Enabled = conection;
                this.medidasToolStripMenuItem.Enabled = conection;
                this.menuAdministrar.Enabled = conection;
                this.menuInventario.Enabled = conection;
                this.menuCompras.Enabled = conection;
                this.menuVentas.Enabled = conection;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void HabilitarMenuCosultaCompra(bool actived)
        {
            this.MenuComprasDeProducto.Visible = actived;
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
            string rta = "";
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
            }
        }

        Administracion.Caja.FrmConsultaCaja Ccaja = null;
        bool Ccj = false;

        private void consultasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string rta = "";
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
            }
        }

        Compras.Egreso.FrmEditarEgreso egreso = null;
        bool com = false;

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

        Administracion.CajaDiario.FrmConsultaCajaFecha ccaja = null;
        bool ccj = false;

        Administracion.CajaDiario.FrmCajaDiario cajaD = null;
        bool cD = false;

        private void reporteCajaDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ccj)
                ccaja = null;
            try
            {
                Administracion.CajaDiario.FrmConsultaCajaFecha cj =
                    (Administracion.CajaDiario.FrmConsultaCajaFecha)this.ActiveMdiChild;
                if (cj == null)
                {
                    ccaja = new Administracion.CajaDiario.FrmConsultaCajaFecha();
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
                    ccaja = new Administracion.CajaDiario.FrmConsultaCajaFecha();
                    ccaja.MdiParent = this;
                    ccaja.Show();
                    ccj = true;
                }
                else
                    ccj = false;
            }
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

        Ventas.Cliente.FrmAdelanto adelanto = null;
        bool ade = false;

        private void adelentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ade)
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
            }
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
            remisionPos = new Ventas.Remisiones.FrmRemision();
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

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            string rta = "";
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
            }
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

        private void editarPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmEditarPrecio = new
                Ventas.EditarPrecio.FrmPrecioProducto();
            frmEditarPrecio.MdiParent = this;
            frmEditarPrecio.Show();
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
                    string rta = "";
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
                    }
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

        private void informacionDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmInforSystem = new Configuracion.Version.FrmVersion();
            frmInforSystem.ShowDialog();
        }

        Inventario.Kardex.FrmKardex frmKardex = null;
        bool k = false;

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
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
            var frmResumen = new Ventas.Factura.FrmResumenVenta();
            frmResumen.MdiParent = this;
            frmResumen.Show();
           /* var frmUtilidad = new Ventas.Factura.FrmUtilidad();
            frmUtilidad.MdiParent = this;
            frmUtilidad.Show();*/
        }
    }
}