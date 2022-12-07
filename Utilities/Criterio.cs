using System;
using System.Collections.Generic;

namespace Utilities
{
    public class Seleccion
    {
        public static List<MiCriterio> Meses()
        {
            var meses = new List<MiCriterio>();
            meses.Add(new MiCriterio { id = 1, Nombre = "Ene" });
            meses.Add(new MiCriterio { id = 2, Nombre = "Feb" });
            meses.Add(new MiCriterio { id = 3, Nombre = "Mar" });
            meses.Add(new MiCriterio { id = 4, Nombre = "Abr" });
            meses.Add(new MiCriterio { id = 5, Nombre = "May" });
            meses.Add(new MiCriterio { id = 6, Nombre = "Jun" });
            meses.Add(new MiCriterio { id = 7, Nombre = "Jul" });
            meses.Add(new MiCriterio { id = 8, Nombre = "Ago" });
            meses.Add(new MiCriterio { id = 9, Nombre = "Sep" });
            meses.Add(new MiCriterio { id = 10, Nombre = "Oct" });
            meses.Add(new MiCriterio { id = 11, Nombre = "Nov" });
            meses.Add(new MiCriterio { id = 12, Nombre = "Dic" });
            return meses;
        }

        public static List<int> Dias(int mes)
        {
            var dias = new List<int>();
            if(mes != 2)
            {
                if(mes == 4 || mes == 6 || mes == 9 || mes== 11)
                {
                    for (int i = 1; i <= 30; i++)
                    {
                        dias.Add(i);
                    }
                }
                else
                {
                    for (int i = 1; i <= 31; i++)
                    {
                        dias.Add(i);
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 28; i++)
                {
                    dias.Add(i);
                }
            }
            return dias;
        }
    }

    public class MiCriterio
    {
        public int id { set; get; }
        public string Nombre { set; get; }
    }

    /// <summary>
    /// creo los criterios de categoria
    /// </summary>
    public class CargarCriterioCategoria
    {
        public List<CargarListaCriterioCategoria1> Lista1;
        public List<CargarListaCriterioCategoria2> Lista2;

        public CargarCriterioCategoria()
        {
            this.Lista1 = new List<CargarListaCriterioCategoria1>();
            this.Lista1.Add(new CargarListaCriterioCategoria1
            {
                Id1 = 1,
                Nombre1 = "Por Codigo"
            });
            this.Lista1.Add(new CargarListaCriterioCategoria1
            {
                Id1 = 2,
                Nombre1 = "Por Nombre"
            });

            this.Lista2 = new List<CargarListaCriterioCategoria2>();
            this.Lista2.Add(new CargarListaCriterioCategoria2
            {
                Id2 = 1,
                Nombre2 = "Sea Igual"
            });
            this.Lista2.Add(new CargarListaCriterioCategoria2
            {
                Id2 = 2,
                Nombre2 = "Que Contenga"
            });
        }
    }

    public class CargarListaCriterioCategoria1
    {
        public int Id1 { set; get; }
        public string Nombre1 { set; get; }
    }

    public class CargarListaCriterioCategoria2
    {
        public int Id2 { set; get; }
        public string Nombre2 { set; get; }
    }

    /// <summary>
    /// Cargo los criterios de busqueda  de zona
    /// </summary>
    public class CargarCriteriosZona
    {
       public List<CargarListaCriterioZona> lista1;

       public CargarCriteriosZona()
        {
            this.lista1=new List<CargarListaCriterioZona>();
            this.lista1.Add(new CargarListaCriterioZona
            {
               id=1,
               Nombre="Por Nombre"
            });
            this.lista1.Add(new CargarListaCriterioZona
            {
                id=2,
                Nombre="Por Capacidad"
            });
        }

     }

    /// <summary>
    /// Lista los criterios de aplica venta.
    /// </summary>
    public class CargarCriteriosAplicaventa
    {
        public List<CargarListaCriterioZona> listaAplica;
        public List<CargarListaCriterioZona> listaAplica2;
        public CargarCriteriosAplicaventa()
        {
            this.listaAplica = new List<CargarListaCriterioZona>();
            this.listaAplica.Add(new CargarListaCriterioZona
                {
                    id=1,
                    Nombre="Venta minima"
                });
            this.listaAplica.Add(new CargarListaCriterioZona
                {
                    id = 2,
                    Nombre = "Unidad de producto"
                });

            this.listaAplica2 = new List<CargarListaCriterioZona>();
            this.listaAplica2.Add(new CargarListaCriterioZona
            {
                id = 1,
                Nombre = "Venta minima"
            });
            this.listaAplica2.Add(new CargarListaCriterioZona
            {
                id = 2,
                Nombre = "Compra"
            });
        }
    }    

    /// <summary>
    /// Lista los criterios tiquete multiple
    /// </summary>
    public class CargaCriterioTiqueteMultiple
    {
        public List<CargarListaCriterioZona> listaTiquete;
        public CargaCriterioTiqueteMultiple()
        {
            this.listaTiquete = new List<CargarListaCriterioZona>();
            this.listaTiquete.Add(new CargarListaCriterioZona
                {
                    id = 1,
                    Nombre = "Articulo"
                });
            this.listaTiquete.Add(new CargarListaCriterioZona
                {
                    id = 2,
                    Nombre = "Compra"
                });
        }
    }   

    /// <summary>
    /// carga los criterios de busqueda primarios de el sorteo
    /// </summary>
    public class CargaCriterioSorteo
    {
        public IList<CargaListaCriterioSorteo> listaCriteriosSorteo;

        public CargaCriterioSorteo()
        {
            this.listaCriteriosSorteo = new List<CargaListaCriterioSorteo>();
            this.listaCriteriosSorteo.Add(new CargaListaCriterioSorteo
            {
                id = 1,
                Nombre = "Sorteos activos"
            });
            this.listaCriteriosSorteo.Add(new CargaListaCriterioSorteo
                {
                    id = 2,
                    Nombre = "Historial de sorteo"
                });
        }
    }

    /// <summary>
    /// Carga los criterios de busqueda de sorteo.
    /// </summary>
    public class CargaCritriosSorteo
    {
        public List<CargaListaCriterioSorteo> listaSorteo;

        public CargaCritriosSorteo()
        {
            this.listaSorteo = new List<CargaListaCriterioSorteo>();
            this.listaSorteo.Add(new CargaListaCriterioSorteo
                {
                    id = 1,
                    Nombre = "Nombre"
                });
            this.listaSorteo.Add(new CargaListaCriterioSorteo
                {
                    id = 2,
                    Nombre = "Patrocinadores"
                });
            this.listaSorteo.Add(new CargaListaCriterioSorteo
                {
                    id = 3,
                    Nombre = "Tipo de sorteo"
                });
            this.listaSorteo.Add(new CargaListaCriterioSorteo
                {
                    id = 4,
                    Nombre = "Fechas"
                });
            this.listaSorteo.Add(new CargaListaCriterioSorteo
                {
                    id = 5,
                    Nombre = "Periodos"
                });
            this.listaSorteo.Add(new CargaListaCriterioSorteo
                {
                    id = 6,
                    Nombre = "Inicializacion de sorteo"
                });
            this.listaSorteo.Add(new CargaListaCriterioSorteo
            {
                id = 7,
                Nombre = "Finalizacion de sorteo"
            });
            this.listaSorteo.Add(new CargaListaCriterioSorteo
            {
                id = 8,
                Nombre = "Fecha de sorteo"
            });
           
        }
    }   

    /// <summary>
    /// Carga los criterios de busqueda por fechas.
    /// </summary>
    public class CargaCriterioFechaSorteo
    {
        public List<CargaListaCriterioFechaSorteo> listafechas;        

        public CargaCriterioFechaSorteo()
        {
            this.listafechas = new List<CargaListaCriterioFechaSorteo>();
            this.listafechas.Add(new CargaListaCriterioFechaSorteo
           {
               id = 1,
               Nombre = "Fecha Simple"
           });
            this.listafechas.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 2,
                    Nombre = "Periodos de fecha"
                });
            
        }
    }

    public class CargaCriterioHora
    {
        public List<CargaListaCriterioFechaSorteo> listahora;
        public CargaCriterioHora()
        {
            this.listahora = new List<CargaListaCriterioFechaSorteo>();
            this.listahora.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 1,
                    Nombre = "No Aplica Hora"
                });
            this.listahora.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 2,
                    Nombre = "Aplica Hora"
                });
        }
    }  

    public class CargarCriterioPromocion
    {
        public List<CargaListaCriterioFechaSorteo> listacriteriopromocion;
        public CargarCriterioPromocion()
        {
            this.listacriteriopromocion = new List<CargaListaCriterioFechaSorteo>();
            this.listacriteriopromocion.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 1,
                    Nombre = "Fechas"
                });
            this.listacriteriopromocion.Add(new CargaListaCriterioFechaSorteo 
            {
                id=2,
                Nombre= "Periodos"
            });
           
        }
    }

    /// <summary>
    /// Carga los criterios de busqueda de usuario.
    /// </summary>
    public class CargarCriterioUsuario
    {
        /// <summary>
        /// carga la lista de criterio de busqueda sea igual o que contenga.
        /// </summary>
        public List<CargaListaCriterioFechaSorteo> listaCriterioUsuario;

        /// <summary>
        /// Carga la lista de criterio de busqueda de usuario por(doc,nom,cargo). 
        /// </summary>
        public List<CargaListaCriterioFechaSorteo> listaCriterioUsuario_;
        public CargarCriterioUsuario()
        {
            this.listaCriterioUsuario = new List<CargaListaCriterioFechaSorteo>();
            this.listaCriterioUsuario.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 1,
                    Nombre = "Sea igual"
                });
            this.listaCriterioUsuario.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 2,
                    Nombre = "Que Contenga"
                });

            this.listaCriterioUsuario_ = new List<CargaListaCriterioFechaSorteo>();
            this.listaCriterioUsuario_.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 1,
                    Nombre = "Documento"
                });
            this.listaCriterioUsuario_.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 2,
                    Nombre = "Nombre"
                });
            this.listaCriterioUsuario_.Add(new CargaListaCriterioFechaSorteo
                {
                    id = 3,
                    Nombre = "Cargo"
                });

        }
    }

    public class CargaListaCriterioFechaSorteo
    {
        public int id { set; get; }
        public string Nombre { set; get; }
    }

    public class CargaListaCriterioSorteo
    {
        public int id { set; get; }
        public string Nombre { set; get; }
    }

    public class CargarListaCriterioZona
    {
        public int id { set; get; }
        public string Nombre { set; get; }
    }

    public class DetalleProducto
    {
        public string Codigo { set; get; }

        public int Medida { set; get; }

        public int Color { set; get; }

        public double Cantidad { set; get; }

        public double ValorUnitario { set; get; }

        public int Valor { set; get; }

        public double Descto { set; get; }

        public double Impoconsumo { set; get; }

        public DetalleProducto()
        {
            this.Codigo = "";
            this.Medida = 0;
            this.Color = 0;
            this.Cantidad = 0;
            this.ValorUnitario = 0.0;
            this.Valor = 0;
            this.Descto = 0.0;
            this.Impoconsumo = 0.0;
        }
    }
}