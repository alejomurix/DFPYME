using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.Clases;

namespace Utilities
{
    public class PreciosDeProducto
    {
        

        public bool UtilidadAntesIva { set; get; }

        public bool CalculoUtilMultiplicado { set; get; }

        public bool RegimenComun { set; get; }

        public bool Redondear { set; get; }

        public bool AproximarPrecio { set; get; }


        public Producto producto { set; get; }


        public double Costo { set; get; }

        public double CostoIva { set; get; }

        public double CostoMasIvaMasIco { set; get; }


        private double Utilidad { set; get; }

        private double BaseVenta { set; get; }

        private double ValorVentaSinIco { set; get; }

        private double Descuento { set; get; }

        private double ValorDescto { set; get; }


        //private double Iva { set; get; }

        public double ValorUtilidad { set; get; }

        public double ValorIvaUtilidad { set; get; }

        public double ValorVenta { set; get; }

        public double ValorVentaConDescto { set; get; }


        public PreciosDeProducto()
        {
            this.producto = new Producto();
            this.UtilidadAntesIva = true;
            this.CalculoUtilMultiplicado = true;
            this.RegimenComun = false;
            this.Redondear = true;
            this.AproximarPrecio = true;

            this.Costo = 0;
            this.CostoIva = 0;
            this.CostoMasIvaMasIco = 0;

            this.Utilidad = 0;
            this.BaseVenta = 0;
            this.ValorVentaSinIco = 0;
            this.Descuento = 0;
            this.ValorDescto = 0;
            this.ValorUtilidad = 0;
            this.ValorIvaUtilidad = 0;
            this.ValorVenta = 0;
            this.ValorVentaConDescto = 0;

            try
            {
                /*this.Costo = this.producto.ValorCosto;
                this.CostoIva = Math.Round((this.Costo * this.producto.ValorIva / 100), 2);
                this.CostoMasIvaMasIco = Math.Round((this.Costo + Math.Round((this.Costo * this.producto.ValorIva / 100), 4)), 2)
                    + this.producto.Impoconsumo;*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void CargarCosto()
        {
            try
            {
                this.Costo = this.producto.ValorCosto;
                this.CostoIva = Math.Round((this.Costo * this.producto.ValorIva / 100), 2);
                this.CostoMasIvaMasIco = Math.Round((this.Costo + Math.Round((this.Costo * this.producto.ValorIva / 100), 4)), 2)
                    + this.producto.Impoconsumo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarPrecio()
        {
            if (!this.UtilidadAntesIva)
            {
                if (!this.RegimenComun)
                {
                    this.Costo = this.CostoMasIvaMasIco;
                }
                if (this.CalculoUtilMultiplicado)
                {
                    this.ValorUtilidad = Math.Round((this.Costo * this.Utilidad / 100), 2);
                }
                else
                {
                    this.ValorUtilidad = Math.Round(((this.Costo / ((100 - this.Utilidad) / 100)) - this.Costo), 2);
                }
                if (this.RegimenComun)
                {
                    this.ValorIvaUtilidad = Math.Round((this.ValorUtilidad * this.producto.ValorIva / 100), 2);
                }
            }
            else
            {
                if (this.CalculoUtilMultiplicado)
                {
                    this.ValorUtilidad = Math.Round((this.CostoMasIvaMasIco * this.Utilidad / 100), 2);
                }
                else
                {
                    this.ValorUtilidad = Math.Round(((this.CostoMasIvaMasIco / ((100 - this.Utilidad) / 100)) - this.CostoMasIvaMasIco), 2);
                }
            }
            this.ValorVenta = Convert.ToInt32(this.CostoMasIvaMasIco + this.ValorUtilidad + this.ValorIvaUtilidad);

            this.ValorVentaSinIco = this.producto.ValorVentaProducto - Convert.ToInt32(this.producto.Impoconsumo);
            this.ValorDescto = Math.Round((this.ValorVentaSinIco * this.Descuento / 100), 1); //¿Cual es la diferencia en este procedimiento y remplazarlo al calculo de la linea de abajo?
            this.ValorVentaConDescto = (Convert.ToInt32(this.ValorVentaSinIco - this.ValorDescto)) + Convert.ToInt32(this.producto.Impoconsumo);

            if (this.Redondear)
            {
                this.ValorVentaConDescto = UseObject.Aproximar(Convert.ToInt32(this.ValorVentaConDescto), this.AproximarPrecio);
            }
        }

        private void CargarPrecioValorVenta() // Edicion de precio, edicion de descuento
        {
            if (!this.RegimenComun)
            {
                this.Costo = this.CostoMasIvaMasIco;
            }
            if (!this.UtilidadAntesIva)
            {
                if (this.RegimenComun)
                {
                    this.BaseVenta = Convert.ToInt32(this.ValorVentaSinIco / (1 + (this.producto.ValorIva / 100)));
                }
            }
            if (this.CalculoUtilMultiplicado)
            {
                //this.ValorUtilidad = Math.Round((((this.ValorVentaSinIco - this.Costo) * 100) / this.Costo), 2);
                this.Utilidad = Math.Round((((this.BaseVenta - this.Costo) * 100) / this.Costo), 2);
                this.ValorUtilidad = Math.Round((this.Costo * this.Utilidad / 100), 2);
            }
            else
            {
                //this.ValorUtilidad = Math.Round((this.Costo / this.ValorVentaSinIco), 2);
                //this.ValorUtilidad = Math.Round((100 - ((this.Costo / this.ValorVentaSinIco) * 100)), 1);
                this.Utilidad = Math.Round((100 - ((this.Costo / this.BaseVenta) * 100)), 1);
                this.ValorUtilidad = Math.Round(((this.Costo / ((100 - this.Utilidad) / 100)) - this.Costo), 2);
            }
            if (this.RegimenComun)
            {
                this.ValorIvaUtilidad = Math.Round((this.ValorUtilidad * this.producto.ValorIva / 100), 2);
            }
            // pVenta: calcular descuento
            this.Descuento = Math.Round((((this.ValorVentaSinIco - this.ValorVentaConDescto) / this.ValorVentaSinIco) * 100), 3);

            // descto: calcula precio de venta pVenta2
            this.ValorDescto = Math.Round((this.ValorVentaSinIco * this.Descuento / 100), 1); //¿Cual es la diferencia en este procedimiento y remplazarlo al calculo de la linea de abajo?
            this.ValorVentaConDescto = Convert.ToInt32(this.ValorVentaSinIco - this.ValorDescto);
            
            
        }

        public void CargarPrecioUno()
        {
            this.Utilidad = this.producto.UtilidadPorcentualProducto;
            this.CargarPrecio();
        }

        public void CargarPrecioDos()
        {
            this.Utilidad = this.producto.Utilidad2;
            this.Descuento = this.producto.DescuentoMayor;
            this.CargarPrecio();
        }

        public void CargarPrecioTres()
        {
            this.Utilidad = this.producto.Utilidad3;
            this.Descuento = this.producto.DescuentoDistribuidor;
            this.CargarPrecio();
        }

        public void CargarPrecioCuatro()
        {
        }


        public enum OpcionCosto { CostoNoIva, Iva, Impoconsumo, CostoMasIva };

        public void EditarCosto(OpcionCosto opcion)
        {
            switch (opcion) // Opción de la variable que trae la edición.
            {
                case OpcionCosto.CostoNoIva:
                    {
                        this.CostoIva = Math.Round((this.Costo * this.producto.ValorIva / 100), 2);
                        this.CostoMasIvaMasIco = this.Costo + this.CostoIva + this.producto.Impoconsumo;
                        break;
                    }
                case OpcionCosto.Iva:
                    {
                        this.Costo = this.CostoMasIvaMasIco - this.producto.Impoconsumo;
                        this.Costo = Math.Round((this.Costo / (1 + (this.producto.ValorIva / 100))), 2);
                        this.CostoIva = Math.Round((this.Costo - (this.CostoMasIvaMasIco - this.producto.Impoconsumo)), 2);
                        break;
                    }
                case OpcionCosto.Impoconsumo:
                    {
                        this.CostoMasIvaMasIco = this.Costo + this.CostoIva + this.producto.Impoconsumo;
                        break;
                    }
                case OpcionCosto.CostoMasIva:
                    {
                        this.CostoMasIvaMasIco -= this.producto.Impoconsumo;
                        this.Costo = Math.Round((this.CostoMasIvaMasIco / (1 + (this.producto.ValorIva / 100))), 2);
                        this.CostoIva = Math.Round(this.CostoMasIvaMasIco - this.Costo, 2);
                        this.CostoMasIvaMasIco += this.producto.Impoconsumo;
                        break;
                    }
            }
        }

        //public void 
    }
}