using System;
using System.Collections.Generic;

namespace Aplicacion.Clases
{
    /// <summary>
    /// creo losa criterios de categoria
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
}