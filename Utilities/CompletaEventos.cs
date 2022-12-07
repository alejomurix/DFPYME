using System;

namespace Utilities
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

        public delegate void CompletaAccionEditProveedor(CompletaArgumentosDeEventoEditProveedor args);
        public static event CompletaAccionEditProveedor CompletaEditProveedor;

        public delegate void CompletaAccionEditFactura(CompletaArgumentosDeEventoEditFactura args);
        public static event CompletaAccionEditFactura CompletaEditFactura;

        public delegate void CompletaAccionRemision(CompletaArgumentosDeEventoRemision arg);
        public static event CompletaAccionRemision CompletaRemision;

        public delegate void CompletaAccionAdelanto(CompletaArgumentosDeAdelanto args);
        public static event CompletaAccionAdelanto CompletaAdelanto;

        public delegate void CompletaAccionVenta(CompletaArgumentosDeEventoVenta args);
        public static event CompletaAccionVenta CompletaVenta;

        public delegate void CompletaAccionRetiroBono(CompletaArgumentosRetiroBono args);
        public static event CompletaAccionRetiroBono CompletaRetiroBono;

        public delegate void CompletaAccionRetiroSaldo(CompletaArgumentosRetiroSaldo args);
        public static event CompletaAccionRetiroSaldo CompletaRetiroSaldo;

        public delegate void CompletaAccionRetiroAdelanto(CompletaArgumentosRetiroAdelanto args);
        public static event CompletaAccionRetiroAdelanto CompletaRetiroAdelanto;

        public delegate void ComAxAbonoFact(CompArgAbonoFact args);
        public static event ComAxAbonoFact ComAbonoFact;

        public delegate void ComAxAbonoRemision(CompArgAbonoRemision args);
        public static event ComAxAbonoRemision ComAbonoRemision;

        public delegate void ComAxAbonoEgreso(CompletaAbonoEgreso arg);
        public static event ComAxAbonoEgreso ComAbonoEgreso;

        public delegate void ComAxTransferProductFact(CompletaTransferProductFact args);
        public static event ComAxTransferProductFact CompTProductoFact;

        public delegate void ComAxTransferInvFactProve(CompletaTransInvFactProvee args);
        public static event ComAxTransferInvFactProve CompAxTInvFactProvee;


        public static void CapturaEvento(object elObjeto)
        {
            if (Completa != null)
            {
                Completa(new CompletaArgumentosDeEvento(elObjeto));
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

        public static void CapturaEventoEditProveedor(object elObjeto)
        {
            if (CompletaEditProveedor != null)
            {
                CompletaEditProveedor(new CompletaArgumentosDeEventoEditProveedor(elObjeto));
            }
        }

        public static void CapturaEventoEditFactura(object elObjeto)
        {
            if (CompletaEditProveedor != null)
            {
                CompletaEditProveedor(new CompletaArgumentosDeEventoEditProveedor(elObjeto));
            }
        }

        public static void CapturaEventoRemision(object elObjeto)
        {
            if (CompletaRemision != null)
            {
                CompletaRemision(new CompletaArgumentosDeEventoRemision(elObjeto));
            }
        }

        public static void CapturaEventoAdelanto(object elObjeto)
        {
            if (CompletaAdelanto != null)
            {
                CompletaAdelanto(new CompletaArgumentosDeAdelanto(elObjeto));
            }
        }

        public static void CapturaEventoVenta(object Objeto)
        {
            if (CompletaVenta != null)
            {
                CompletaVenta(new CompletaArgumentosDeEventoVenta(Objeto));
            }
        }

        public static void CapturaEventoRetiroBono(object objeto)
        {
            if (CompletaRetiroBono != null)
            {
                CompletaRetiroBono(new CompletaArgumentosRetiroBono(objeto));
            }
        }

        public static void CapturaEventoRetiroSaldo(object objeto)
        {
            if (CompletaRetiroSaldo != null)
            {
                CompletaRetiroSaldo(new CompletaArgumentosRetiroSaldo(objeto));
            }
        }

        public static void CapturaEventoRetiroAdelanto(object objeto)
        {
            if (CompletaRetiroAdelanto != null)
            {
                CompletaRetiroAdelanto(new CompletaArgumentosRetiroAdelanto(objeto));
            }
        }

        public static void CapEvenAbonoFact(object objeto)
        {
            if (ComAbonoFact != null)
            {
                ComAbonoFact(new CompArgAbonoFact(objeto));
            }
        }

        public static void CapEvenAbonoRemision(object objeto)
        {
            if (ComAbonoRemision != null)
            {
                ComAbonoRemision(new CompArgAbonoRemision(objeto));
            }
        }

        public static void CapEventoAbonoEgreso(object objeto)
        {
            if (ComAbonoEgreso != null)
            {
                ComAbonoEgreso(new CompletaAbonoEgreso(objeto));
            }
        }

        public static void CapEventoTransferProductFact(object objeto)
        {
            if (CompTProductoFact != null)
            {
                CompTProductoFact(new CompletaTransferProductFact(objeto));
            }
        }

        public static void CapturaEvenTransInvFactProvee(object objeto)
        {
            if (CompAxTInvFactProvee != null)
            {
                CompAxTInvFactProvee(new CompletaTransInvFactProvee(objeto));
            }
        }

    }

    public class CompletaArgumentosDeEventoVenta : EventArgs
    {
        public CompletaArgumentosDeEventoVenta(object Objeto)
        {
            this.objeto = Objeto;
        }

        public object objeto { set; get; }
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

    public class CompletaArgumentosDeEventoEditProveedor : EventArgs
    {
        public CompletaArgumentosDeEventoEditProveedor(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompletaArgumentosDeEventoEditFactura : EventArgs
    {
        public CompletaArgumentosDeEventoEditFactura(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompletaArgumentosDeEventoRemision
    {
        public CompletaArgumentosDeEventoRemision(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompletaArgumentosDeAdelanto
    {
        public CompletaArgumentosDeAdelanto(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto{ set ; get; }
    }

    public class CompletaArgumentosRetiroBono
    {
        public CompletaArgumentosRetiroBono(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompletaArgumentosRetiroSaldo
    {
        public CompletaArgumentosRetiroSaldo(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompletaArgumentosRetiroAdelanto
    {
        public CompletaArgumentosRetiroAdelanto(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompArgAbonoFact
    {
        public CompArgAbonoFact(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompArgAbonoRemision
    {
        public CompArgAbonoRemision(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompletaAbonoEgreso
    {
        public CompletaAbonoEgreso(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompletaTransferProductFact
    {
        public CompletaTransferProductFact(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }

    public class CompletaTransInvFactProvee
    {
        public CompletaTransInvFactProvee(object miObjeto)
        {
            this.MiObjeto = miObjeto;
        }

        public object MiObjeto { set; get; }
    }
}