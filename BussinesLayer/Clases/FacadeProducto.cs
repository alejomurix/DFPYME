using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Clases;
using DTO.Clases;
using System.Collections;
using System.Data;


namespace BussinesLayer.Clases
{
   public class FacadeProducto
    {

       private DaoProducto miProducto;
       
       
       public FacadeProducto()
       {
           miProducto = new DaoProducto();
       }
       public void InsertarProducto(Producto producto)
       {

           miProducto.InsertarProducto(producto);
       }

     
       public ArrayList ListarProductos()
       {


          return  miProducto.ListarProductos();


       }

       public ArrayList ListarProductoscodigobarras(int codigobarras)
       {
          
           return miProducto.ListarProductoscodigobarras(codigobarras);
       }

       public ArrayList ListarProductoscodigointerno(string codigointerno)
       {

           return miProducto.ListarProductoscodigointerno(codigointerno);
       }

       public Producto ListarProductoCompletoCodigointerno(string codigointerno)
       {

           return miProducto.ListarProductoCompletoCodigointerno(codigointerno);
       }

       public void EditarProducto(Producto producto)
       {

           miProducto.EditarProducto(producto);
       
       }
       public ArrayList ListarProductosNombre(string nombreproducto)
       {

           return miProducto.ListarProductosNombre(nombreproducto);
       }

       public ArrayList ListarProductosNombreCategoria(string nombrecategoria)
       {

           return miProducto.ListarProductosNombreCategoria(nombrecategoria);
       }
       public ArrayList ListarProductosCodigoCategoria(string codigocategoria)
       {

           return miProducto.ListarProductosCodigoCategoria(codigocategoria);
       }

       public ArrayList ListarProductosMarca(string nombremarca)
       {

           return miProducto.ListarProductosMarca(nombremarca);
       }
       public void Eliminar_Producto(string codigointerno)
       {
           miProducto.Eliminar_Producto(codigointerno);
       }

       public Int64 CapturarCodbarras()
       {
           return miProducto.capturarcodbarras();

       }

       public void actualizarProductoBarras(int productobarras)
       {
           miProducto.ActualizarProductoBarras(productobarras);
       }
       
       public String CapturarCodInterno()
       {
           return miProducto.capturarcodinterno();

       }
       public void actualizarProductoCodInterno(int codinterno)
       {
           miProducto.ActualizarProductoInterno(codinterno);
       }

    }
       
       }

    

