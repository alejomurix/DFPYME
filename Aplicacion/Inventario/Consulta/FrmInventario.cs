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
using DTO.Clases;
using Utilities;
using System.Threading;

namespace Aplicacion.Inventario.Consulta
{
    public partial class FrmInventario : Form
    {
        #region Atributos

        private BussinesInventario miBussinesInventario;

        private BussinesProducto miBussinesProducto;

        private ToolTip miToolTip;

        private bool ExtendForms { set; get; }

        public bool ExtendForms_ { set; get; }

        public bool ExtendVenta = false;

        public bool IsVenta = true;

        public bool IsCompra = false;

        private DataTable Tabla { set; get; }

        private Thread miThread;

        private OptionPane miOption;

        private int Iteracion;

        private int RowInventario;

        private int RowMaxInventario;

        private long Pages;

        private long TotalRows;

        private int CurrentPage;

        private string CodigoActual;

        private string NombreActual;

        private string CategoriaActual;

        public int IdTipoInventarioNoFabricado { set; get; }

        public int IdTipoInventarioFabricado { set; get; }

        #endregion

        public bool Consulta { set; get; }

        //private bool CostoInventario;

        private BindingSource miBindingSource;

        private Validacion validacion;

        public FrmInventario()
        {
            InitializeComponent();
           // CostoInventario = Convert.ToBoolean(AppConfiguracion.ValorSeccion("costo_inventario"));
            tsEditarPrecio.Visible = true;
            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costo_inventario")))
            {
                

                Precio2.Visible = false;
                Inventario.Visible = false;
                Valor.Visible = true;
            }

            miBindingSource = new BindingSource();
            validacion = new Validacion();
            miBussinesProducto = new BussinesProducto();

           /* miBussinesInventario = new BussinesInventario();
            miBussinesProducto = new BussinesProducto();
            miToolTip = new ToolTip();
            RowMaxInventario = 15;
            
            this.Consulta = true;
            this.ExtendForms_ = false;

            IdTipoInventarioNoFabricado = 1;
            IdTipoInventarioFabricado = 1;*/
        }

        private void FrmConsultaInventario_Load(object sender, EventArgs e)
        {
            dgvInventario.AutoGenerateColumns = false;
            dgvInventario.DataSource = miBindingSource;
            if (ExtendVenta)
            {
                if (!String.IsNullOrEmpty(txtCodigoNombre.Text))
                {
                    txtCodigoNombre_KeyPress(txtCodigoNombre, new KeyPressEventArgs((char)Keys.Enter));
                }
            }


            /*CargarUtilidades();
            dgvInventario.AutoGenerateColumns = false;
            CompletaEventos.CompletaEditProveedor += 
                new CompletaEventos.CompletaAccionEditProveedor(CompletaEventos_Completo);
            CompletaEventos.Completam += 
                new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            try
            {
                ImgCostoStream = assembly.GetManifestResourceStream(ImagenLote);
                ImgPdistriStream = assembly.GetManifestResourceStream(ImagenPdistri);
            }
            catch
            {
                OptionPane.MessageError("Ocurrió un error al cargar los recursos.");
            }
            if (ExtendVenta)
            {
                Valor.Visible = false;
                dgvInventario.Columns["Producto"].Width = 425; //605;
                tsVerCosto.Enabled = true;

                tsBtnSeleccionar.Visible = true;
                cbCriterio1.SelectedValue = 2;
                if (Consulta)
                {
                    btnConsultar_Click(this.btnConsultar, new EventArgs());
                }
            }
            else
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("verCosto")))
                {
                    
                }
                else
                {
                    tsVerCosto.Enabled = true;
                    Valor.Visible = false;
                    dgvInventario.Columns["Producto"].Width = Producto.Width + Valor.Width;
                }
            }
            tsVerPrecioDistri.Image = new Bitmap(ImgPdistriStream);
            tsVerPrecioDistri.Text = "No ver P. Distribuidor(3)";
            dgvInventario.Columns["PDistribuidor"].Visible = true;*/
        }

        private void FrmConsultaInventario_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }
           /* switch (e.KeyData)
            {
                
                
                
                case Keys.F5:
                    {
                        this.tsBtnListarTodos_Click(this.tsBtnListarTodos, new EventArgs());
                        break;
                    }
                case Keys.F7:
                    {
                        //this.dgvInventario.Focus();
                        this.tsBtnSelecionaGrid_Click(this.tsBtnSelecionaGrid, new EventArgs());
                        break;
                    }
                case Keys.F9:
                    {
                        this.tsBtnNuevoArticulo_Click(this.tsBtnNuevoArticulo, new EventArgs());
                        break;
                    }
                case Keys.F10:
                    {
                        this.tsBtnImprimirConsulta_Click(this.tsBtnImprimir, new EventArgs());
                        break;
                    }
                case Keys.F11:
                    {
                        this.tsBtnImprimir_Click(this.tsBtnImprimirConsulta, new EventArgs());
                        break;
                    }
                case Keys.F12:
                    {
                        this.tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
                        break;
                    }
                case Keys.Add: // " + "
                    {
                        if (this.dgvInventario.Focused)
                        {
                            this.btnSiguiente_Click(this.btnSiguiente, new EventArgs());
                        }
                        break;
                    }
                case Keys.Subtract:  // " - "
                    {
                        if (this.dgvInventario.Focused)
                        {
                            this.btnAnterior_Click(this.btnAnterior, new EventArgs());
                        }
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }*/
        }

        private void FrmConsultaInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExtendVenta)
            {
                if (IsCompra)
                {
                    CompletaEventos.CapturaEvenTransInvFactProvee(false);
                }
                else
                {
                    if (IsVenta)
                    {
                        CompletaEventos.CapturaEvento(false);
                    }
                    else
                    {
                        CompletaEventos.CapturaEventoRemision(false);
                    }
                }
            }
        }


        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            /**this.Iteracion = 1;
            this.CurrentPage = 1;

            this.dgvInventario.AutoGenerateColumns = false;

            miOption = new OptionPane();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
            miOption.FrmProgressBar.Closed_ = true;
            miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                "Operacion en progreso");
            miThread = new Thread(Consultar);
            miThread.Start();*/

            /*RowInventario = 0;
            Iteracion = 1;
            CurrentPage = 1;
            try
            {
                dgvInventario.DataSource =
                    miBussinesInventario.ConsultaInventario(RowInventario, RowMaxInventario);
                TotalRows = miBussinesInventario.GetRowsConsultaInventario();
                if (dgvInventario.RowCount.Equals(0))
                {
                    OptionPane.MessageInformation("No se encuentran registros en el Inventario.");
                }
                else
                {
                    ColorearGrid();
                    this.dgvInventario.Focus();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CalcularPaginas();*/
        }

        private void tsEditarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInventario.RowCount > 0)
                {
                    dgvInventario.Columns["Precio_"].ReadOnly = false;
                    dgvInventario.EditMode = DataGridViewEditMode.EditOnEnter;
                    dgvInventario.BeginEdit(true);
                }
            }
            catch (Exception){ }
            //Precio_
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void txtCodigoNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    //dgvInventario.DataSource = miBussinesProducto.Productos(txtCodigoNombre.Text.Split(' '));
                    miBindingSource.DataSource = miBussinesProducto.Productos(txtCodigoNombre.Text.Split(' '));
                    ColorearGrid();
                    txtCodigoNombre.SelectAll();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void chkVerId_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerId.Checked)
            {
                Id.Visible = true;
            }
            else
            {
                Id.Visible = false;
            }
        }


        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventario.RowCount != 0)
            {
                TransferData();
                txtCodigoNombre.Focus();
                txtCodigoNombre.SelectAll();
                //tsBtnSeleccionar_Click(this.tsBtnSeleccionar, new EventArgs());
            }
        }

        private void dgvInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!dgvInventario.RowCount.Equals(0))
            {
                bool key = false;
                var precio = 0;
                //var KeyAccess = 0;
                double destoAplica = 0.0;
                if (e.KeyChar.Equals((char)Keys.D1))
                {
                    precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells["Precio_"].Value.ToString()); 
                    //KeyAccess = 1;
                    key = true;
                }
                else
                {
                    if (e.KeyChar.Equals((char)Keys.D2))
                    {
                        precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells["Precio2"].Value.ToString());
                        destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["Descto"].Value); 
                        //KeyAccess = 2;
                        key = true;
                    }
                }
                if (key)
                {
                    var producto = new DTO.Clases.Producto();
                    producto.CodigoInternoProducto = dgvInventario.CurrentRow.Cells["Id"].Value.ToString();
                    producto.Descuento = destoAplica;

                    if (ExtendVenta)
                    {
                        if (IsCompra)
                        {
                            CompletaEventos.CapturaEvenTransInvFactProvee(producto);
                        }
                        else
                        {
                            if (IsVenta)
                            {
                                CompletaEventos.CapEventoTransferProductFact(producto);  //  evento que trasmite a fr venta.
                            }
                            else
                            {
                                CompletaEventos.CapturaEventom(producto);
                            }
                        }
                        //this.Close();
                    }
                }



                /*
                bool key = false;
                var precio = 0;
                var KeyAccess = 0;
                double destoAplica = 0.0;
                if (e.KeyChar.Equals((char)Keys.D1))
                {
                    precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells["Venta"].Value.ToString());
                    KeyAccess = 1;
                    //destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["Venta"].Value);
                    key = true;
                }
                else
                {
                    if (e.KeyChar.Equals((char)Keys.D2))
                    {
                        precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells["PMayor"].Value.ToString());
                        destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["DestoMayor"].Value);
                        KeyAccess = 2;
                        key = true;
                    }
                    else
                    {
                        if (e.KeyChar.Equals((char)Keys.D3))
                        {
                            precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells["PDistribuidor"].Value.ToString());
                            destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["DestoDistri"].Value);
                            KeyAccess = 3;
                            key = true;
                        }
                        else
                        {
                            if (e.KeyChar.Equals((char)Keys.D4))
                            {
                                destoAplica = Convert.ToDouble(dgvInventario.CurrentRow.Cells["DesctoPrecio4"].Value);
                                KeyAccess = 4;
                                key = true;
                            }
                        }
                    }
                }

                if (key)
                {
                        var producto = new DTO.Clases.Producto();
                        producto.CodigoInternoProducto = dgvInventario.CurrentRow.Cells["Codigo"].Value.ToString();
                        producto.Descuento = destoAplica;

                        if (ExtendVenta)
                        {
                            if (IsCompra)
                            {
                                CompletaEventos.CapturaEvenTransInvFactProvee(producto);
                            }
                            else
                            {
                                if (IsVenta)
                                {
                                    CompletaEventos.CapEventoTransferProductFact(producto);  //  evento que trasmite a fr venta.
                                }
                                else
                                {
                                    CompletaEventos.CapturaEventom(producto);
                                }
                            }
                            //CompletaEventos.CapturaEventom(producto);
                            this.Close();
                        }
                }
                */
            }
            else
            {
                OptionPane.MessageInformation("No hay registros para cargar.");
            }
        }




        private void CargarUtilidades()
        {
            /*miToolTip.SetToolTip(btnBuscar, "Buscar Producto [F4].");
            miToolTip.SetToolTip(btnConsultar, "Realizar Consulta.");
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Producto.Criterio
            {
                Id = 1,
                Nombre = "Producto"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 2,
                Nombre = "Categoria"
            });
            cbCriterio.DataSource = lst;

            lst = new List<Producto.Criterio>();
            lst.Add(new Producto.Criterio
            {
                Id = 1,
                Nombre = "Codigo"
            });

            lst.Add(new Producto.Criterio
            {
                Id = 2,
                Nombre = "Contenga Nombre"
            });
            cbCriterio1.DataSource = lst;*/
        }

        private void Consultar()
        {
            try
            {
                if (ExtendVenta)
                {
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                //this.RowMaxInventario = 18000;
                                //this.Tabla = miBussinesInventario.ConsultaInventario(RowInventario, RowMaxInventario);
                                //this.TotalRows = miBussinesInventario.GetRowsConsultaInventario();

                                this.Tabla = miBussinesInventario.ConsultaInventario(IsCompra, RowInventario, RowMaxInventario, IdTipoInventarioNoFabricado, IdTipoInventarioFabricado);
                                this.TotalRows = miBussinesInventario.GetRowsConsultaInventario(IsCompra, IdTipoInventarioNoFabricado, IdTipoInventarioFabricado);
                                break;
                            }
                        case 2:
                            {
                                this.Tabla = miBussinesInventario.ConsultaInventario
                                    (IsCompra, this.CodigoActual, RowInventario, RowMaxInventario, IdTipoInventarioNoFabricado, IdTipoInventarioFabricado);
                                this.TotalRows = miBussinesInventario.GetRowsConsultaInventario(IsCompra, this.CodigoActual, IdTipoInventarioNoFabricado, IdTipoInventarioFabricado);
                                break;
                            }
                        case 3:
                            {
                                this.Tabla = miBussinesInventario.ConsultaInventarioNombre
                                    (IsCompra, this.NombreActual, RowInventario, RowMaxInventario, IdTipoInventarioNoFabricado, IdTipoInventarioFabricado);
                                this.TotalRows = miBussinesInventario.GetRowsConsultaInventarioNombre(IsCompra, this.NombreActual, IdTipoInventarioNoFabricado, IdTipoInventarioFabricado);
                                break;
                            }
                        case 4:
                            {
                                this.Tabla = miBussinesInventario.ConsultaInventarioCategoria
                                    (IsCompra, this.CategoriaActual, RowInventario, RowMaxInventario, IdTipoInventarioNoFabricado, IdTipoInventarioFabricado);
                                this.TotalRows = miBussinesInventario.GetRowsConsultaInventarioCategoria(IsCompra, this.CategoriaActual, IdTipoInventarioNoFabricado, IdTipoInventarioFabricado);
                                break;
                            }
                    }
                }
                else
                {
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                //this.RowMaxInventario = 18000;
                                this.Tabla = miBussinesInventario.ConsultaInventario(RowInventario, RowMaxInventario);
                                this.TotalRows = miBussinesInventario.GetRowsConsultaInventario();
                                break;
                            }
                        case 2:
                            {
                                this.Tabla = miBussinesInventario.ConsultaInventario(this.CodigoActual, RowInventario, RowMaxInventario);
                                this.TotalRows = miBussinesInventario.GetRowsConsultaInventario(this.CodigoActual);
                                break;
                            }
                        case 3:
                            {
                                this.Tabla = miBussinesInventario.ConsultaInventarioNombre(this.NombreActual, RowInventario, RowMaxInventario);
                                this.TotalRows = miBussinesInventario.GetRowsConsultaInventarioNombre(this.NombreActual);
                                break;
                            }
                        case 4:
                            {
                                this.Tabla = miBussinesInventario.ConsultaInventarioCategoria(this.CategoriaActual, RowInventario, RowMaxInventario);
                                this.TotalRows = miBussinesInventario.GetRowsConsultaInventarioCategoria(this.CategoriaActual);
                                break;
                            }
                    }
                }
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar()
        {
            try
            {
                this.dgvInventario.DataSource = this.Tabla;

                txtCodigoNombre.Text = "";
                ColorearGrid();
                //CalcularPaginas();

                /*miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();*/

                if (this.Tabla.Rows.Count.Equals(0))
                {
                    OptionPane.MessageInformation("No se encontraron registros.");
                }
                else
                {
                    if (this.ExtendForms_)
                    {
                        this.dgvInventario.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                /*miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();*/
                OptionPane.MessageError(ex.Message);
            }
        }


        public void ColorearGrid()
        {
            var cont = 0;
            foreach (DataGridViewRow row in dgvInventario.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                    //row.Cells["PrecioVenta"].Style.BackColor = System.Drawing.Color.GradientInactiveCaption;
                    //System.Drawing.Color.CornflowerBlue
                    //PrecioVenta.DefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;
                }
            }
            //PrecioVenta.DefaultCellStyle.BackColor = System.Drawing.Color.CornflowerBlue;
            /*System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1_ = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1_.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1_.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1_.Format = "N0";
            dataGridViewCellStyle1_.NullValue = null;
            this.PrecioVenta.DefaultCellStyle = dataGridViewCellStyle1_;*/
        }

        private void TransferData()
        {
            var producto = new DTO.Clases.Producto();
            producto.CodigoInternoProducto = dgvInventario.CurrentRow.Cells["Id"].Value.ToString();

            if (ExtendVenta)
            {
                if (IsCompra)
                {
                    CompletaEventos.CapturaEvenTransInvFactProvee(producto);
                }
                else
                {
                    if (IsVenta)
                    {
                        CompletaEventos.CapEventoTransferProductFact(producto);  //  evento que trasmite a fr venta.
                    }
                    else
                    {
                        CompletaEventos.CapturaEventom(producto);
                    }
                }
                //CompletaEventos.CapturaEventom(producto);
                //this.Close();
            }
        }

        private void dgvInventario_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex.Equals(8) && (dgvInventario.EditMode == DataGridViewEditMode.EditOnEnter))
            {
                try
                {
                    if (!String.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        if (validacion.ValidarNumeroInt(e.FormattedValue.ToString()))
                        {
                            var code = dgvInventario.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                            var precio = Convert.ToInt32(e.FormattedValue);

                            miBussinesProducto.EditPrice(code, precio);

                            dgvInventario.BeginEdit(false);
                            dgvInventario.EditMode = DataGridViewEditMode.EditProgrammatically;

                            dgvInventario.Focus();
                            txtCodigoNombre.Focus();
                            //dgvInventario.Columns["Precio_"].ReadOnly = true;

                            return;
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        

        

    }

    public class DataGridView_Plus : DataGridView
    {
        /// <summary>
        /// Procesa teclas, como TAB, ESCAPE, ENTRAR, y las teclas de dirección, usadas para
        /// controlar cuadros de diálogo.
        /// </summary>
        /// <param name="keyData">Combinación bit a bit de valores de System.Windows.Form.Keys que representan
        ///  a las teclas que se van a procesar.</param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                return true;
            }
            else
            {
                return base.ProcessDialogKey(keyData);
            }
        }
    }
}