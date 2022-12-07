using System;

namespace Aplicacion.Clases
{
    class PunteDeDatos {}

    public class CompraProveedor
    {
        private static CompraProveedor datos;

        private CompraProveedor() { }

        public static CompraProveedor Instancia()
        {
            if (datos == null)
            {
                datos = new CompraProveedor();
            }
            return datos;
        }

        public int CodigoProveedor { set; get; }

        public string NombreProveedor { set; get; }
    }

    public class TransferirMarca
    {
        private static TransferirMarca t;

        private TransferirMarca() { }
        public static TransferirMarca Instanciam()
        {
            
            if (t == null)
            {
                t = new TransferirMarca();
            }
            return t;
        }

        public int IdMarca { set; get; }
        public string NombreMarca { set; get; }
     
    }

//<<<<<<< .mine
    /// <summary>
    /// Representa un Puente para tranferencia de datos de una Cuenta.
    /// </summary>
    /*public class TransferenciaCuenta
    {
        private static TransferenciaCuenta cuenta;*/
//=======
    /*public class TransferirMarcaem
    {
        private static TransferirMarcaem t;*/
//>>>>>>> .r14

//<<<<<<< .mine
        //private TransferenciaCuenta() { }
//=======
       /* private TransferirMarcaem() { }
        public static TransferirMarcaem Instanciaem()
        {*/
//>>>>>>> .r14

//<<<<<<< .mine
public class TransferenciaCuenta
    {
        private static TransferenciaCuenta cuenta;

     private TransferenciaCuenta() { }
        /// <summary>
        /// Crea una unica instacia de TransferenciaCuenta
        /// </summary>
        /// <returns></returns>
        public static TransferenciaCuenta Instancia()
        {
            if (cuenta == null)
            {
                cuenta = new TransferenciaCuenta();
            }
            return cuenta;
        }


        public int IdTipoCuenta { set; get; }

        public string TipoCuenta { set; get; }

        public string NumeroCuenta { set; get; }

        public string TitularCuenta { set; get; }

        public string NombreBanco { set; get; }
    }

    public class TransferenciaVendedor
    {
        private static TransferenciaVendedor vendedor;

        private TransferenciaVendedor() { }

        public static TransferenciaVendedor Instancia()
        {
            if (vendedor == null)
            {
                vendedor = new TransferenciaVendedor();
            }
            return vendedor;
        }

        public int CedulaContacto { set; get; }
        public string NombreContacto { set; get; }
        public string TelefonoContacto { set; get; }
        public string CelularContacto { set; get; }
        public string EmailContacto { set; get; }
    }

//=======
    public class TransferirMarcaem
    {
        private static TransferirMarcaem t;
         private TransferirMarcaem() { }
        public static TransferirMarcaem Instanciaem()
        {

            if (t == null)
            {
                t = new TransferirMarcaem();
            }
            return t;
        }

        public int IdMarca { set; get; }
        public string NombreMarca { set; get; }

    }
    public class TransferirBodegabo
    {
        private static TransferirBodegabo t;

        private TransferirBodegabo() { }
        public static TransferirBodegabo Instanciabo()
        {

            if (t == null)
            {
                t = new TransferirBodegabo();
            }
            return t;
        }

        public int IdBodega { get; set; }
        public string NombreBodega { get; set; }
        public string LugarBodega { get; set; }

    }

    public class TransferirZona
    {
        private static TransferirZona t;

        private TransferirZona() { }
        public static TransferirZona Instanciaz()
        {

            if (t == null)
            {
                t = new TransferirZona();
            }
            return t;
        }

        public int IdZona { get; set; }
        public string Capacidad { get; set; }
        public int IdBodega { get; set; }
        public int NumeroZona { get; set; }
        public string NombreZona { get; set; }
        public bool DisponibleZona { get; set; }
        public string ValorCapacidad { get; set; }
        public string NombreBodega { get; set; }
        public string LugarBodega { get; set; }


    }
    public class TransferirProducto
    {
        private static TransferirProducto t;

        private TransferirProducto() { }
        public static TransferirProducto Instancia()
        {

            if (t == null)
            {
                t = new TransferirProducto();
            }
            return t;
        }

        public string codigointernoproducto { set; get; }
        public string codigocategoria { set; get; }
        public Int64 codigobarrasproducto { set; get; }
        public string nombreproducto { set; get;}
        public string descripcionproducto { set; get; }
        public int idvalor_unidad_medida { set; get; }
        public int unidadventaproducto { set; get; }
        public int idmarca { set; get; }
        public double utilidadporcentualproducto { set; get; }
        public int valorventaproducto { set; get; }
        public int idiva { set; get; }
        public int cantidadminimaproducto { get; set; }
        public int cantidadmaximaproducto { get; set; }
        public bool estadoproducto { get; set; }
        public string NombreCategoria { get; set; }
        public string UnidadMedida { get; set; }
        public double ValorProcentajeIva { get; set; }
        public string NombreMarca { get; set; }
        public int valorDescuento { get; set; }
        public int valorRecargo { get; set; }
        public string descripcionvalor_unidad_medida { get; set; }
    }
    public class TransferirCategoria
    {
        private static TransferirCategoria t;

        private TransferirCategoria() { }
        public static TransferirCategoria Instancia()
        {

            if (t == null)
            {
                t = new TransferirCategoria();
            }
            return t;
        }

        public string codigocategoria { set; get; }
        public string nombrecategoria { set; get; }
        public string descripcioncategoria { set; get; }
        public string estadocategoria { set; get; }

    }

    public class TransferirIva
    {
        private static TransferirIva t;

        private TransferirIva() { }
        public static TransferirIva Instancia()
        {

            if (t == null)
            {
                t = new TransferirIva();
            }
            return t;
        }

        public int idiva { set; get; }
        public double valoriva { set; get; }
        public string conceptoiva { set; get; }
       

    }
    public class TransferirValorUnidadMedida
    {
        private static TransferirValorUnidadMedida t;

        private TransferirValorUnidadMedida() { }
        public static TransferirValorUnidadMedida Instancia()
        {

            if (t == null)
            {
                t = new TransferirValorUnidadMedida();
            }
            return t;
        }

        public int idvalor_unidad_medida { set; get; }
        public int idunidad_medida { set; get; }
        public int idcolor { set; get; }
        public string descripcionvalor_unidad_medida { set; get; }


    }
    public class TransferirBodegaeb
    {
        private static TransferirBodegaeb t;

        private TransferirBodegaeb() { }
        public static TransferirBodegaeb Instanciaeb()
        {

            if (t == null)
            {
                t = new TransferirBodegaeb();
            }
            return t;
        }

        public int idbodega { set; get; }
        public string nombrebodega { set; get; }
        public string lugarbodega { set; get; }

    }


//>>>>>>> .r14
}