using System;

namespace Aplicacion.Clases
{
    public static class CompletaEventos
    {
        public delegate void CompletaAccion(CompletaArgumentosDeEvento args);
        public static event CompletaAccion Completa;
        public delegate void CompletaAccionm(CompletaArgumentosDeEventom args);
        public static event CompletaAccionm Completam;
        public delegate void CompletaAccionem(CompletaArgumentosDeEventoem args);
        public static event CompletaAccionem Completaem;
        public delegate void CompletaAccioneb(CompletaArgumentosDeEventoeb args);
        public static event CompletaAccioneb Completaeb;
        public delegate void CompletaAccionbo(CompletaArgumentosDeEventobo args);
        public static event CompletaAccionbo Completabo;
        public delegate void CompletaAccionz(CompletaArgumentosDeEventoz args);
        public static event CompletaAccionz Completaz;
        
        public static void CapturaEvento(object elObjeto)
        {
            if (Completa != null)
            {
                Completa( new CompletaArgumentosDeEvento( elObjeto ) );
            }
        }

        

        public static void CapturaEventom(object elObjetom)
        {
            if (Completam != null)
            {
                Completam(new CompletaArgumentosDeEventom(elObjetom));
            }
        }
        public static void CapturaEventoz(object elObjetoz)
        {
            if (Completaz != null)
            {
                Completaz(new CompletaArgumentosDeEventoz(elObjetoz));
            }
        }

        public static void CapturaEventobo(object elObjetobo)
        {
            if (Completabo != null)
            {
                Completabo(new CompletaArgumentosDeEventobo(elObjetobo));
            }
        }

        public static void CapturaEventoem(object elObjetoem)
        {
            if (Completaem != null)
            {
                Completaem(new CompletaArgumentosDeEventoem(elObjetoem));
            }
        }
    

    public static void CapturaEventoeb(object elObjetoeb)
        {
            if (Completaeb != null)
            {
                Completaeb(new CompletaArgumentosDeEventoeb(elObjetoeb));
            }
        }
    
}
    public class CompletaArgumentosDeEvento : EventArgs
    {
        public CompletaArgumentosDeEvento(object miObjeto)
        {
            this.MiObjeto = miObjeto;
            
        }

        public object MiObjeto { set; get; }
        
    }

    public class CompletaArgumentosDeEventoz : EventArgs
    {
        public CompletaArgumentosDeEventoz(object miZona)
        {
            this.MiZona = miZona;

        }

        public object MiZona { set; get; }

    }
        
    public class CompletaArgumentosDeEventom : EventArgs
    {
    public CompletaArgumentosDeEventom(object miMarca)
        {
            this.MiMarca = miMarca;

        }

        public object MiMarca { set; get; }  
    
    }

    public class CompletaArgumentosDeEventobo : EventArgs
    {
        public CompletaArgumentosDeEventobo(object miBodegabo)
        {
            this.MiBodegabo = miBodegabo;

        }

        public object MiBodegabo { set; get; }

    }
    
    public class CompletaArgumentosDeEventoem : EventArgs
    {
        public CompletaArgumentosDeEventoem(object miMarcaed)
        {
            this.MiMarcaed = miMarcaed;

        }

        public object MiMarcaed { set; get; }

    }
    public class CompletaArgumentosDeEventoeb : EventArgs
    {
        public CompletaArgumentosDeEventoeb(object miBodegaeb)
        {
            this.MiBodegaeb = miBodegaeb;

        }

        public object MiBodegaeb { set; get; }

    }


}