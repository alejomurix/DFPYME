using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Models;
using DTO;
using Utilities;

namespace FormulariosSistema
{
    public class PrintInvoice
    {
        //public ElectronicDocument Invoice { set; get; }

        private Ticket Ticket { set; get; }

        private int MaxCharacters { set; get; }

        public PrintInvoice()
        {
            Ticket = new Ticket();
            Ticket.UseItem = false;
            MaxCharacters = 35;
        }

        public void Print(ElectronicDocument Invoice, bool invoice)
        {
            try
            {
                UseObject.StringBuilderDataCenter(Invoice.Company.Company.nombrecomercialempresa, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                UseObject.StringBuilderDataCenter(Invoice.Company.Company.nombrejuridicoempresa, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                UseObject.StringBuilderDataCenter("NIT: " + Invoice.Company.Company.nitempresa + "-" + Invoice.Company.Company.dv, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                UseObject.StringBuilderDataCenter(
                    Invoice.Company.Company.direccionempresa + " " + 
                    Invoice.Company.City.Name + " " + 
                    Invoice.Company.City.Departament.Name, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                UseObject.StringBuilderDataCenter("Tel. " + Invoice.Company.Company.celularempresa, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));

                /// se usa descripción para mostar información sobre regimen tributario.
                UseObject.StringBuilderDataCenter(Invoice.Company.Company.descripcion, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));

                Ticket.AddHeaderLine("");

                if (invoice)
                {
                    Ticket.AddHeaderLine("No. DOC. " + Invoice.Numero);
                }
                else
                {
                    Ticket.AddHeaderLine("No. ORDEN. " + Invoice.Numero);
                }
                Ticket.AddHeaderLine("Fecha: " + Invoice.Fecha.ToShortDateString() + " " +
                    Invoice.Fecha.TimeOfDay.Hours + ":" + Invoice.Fecha.TimeOfDay.Minutes);
                if (Invoice.MetodoPago.Equals(1))
                {
                    Ticket.AddHeaderLine("Contado");
                }
                else
                {
                    Ticket.AddHeaderLine("Crédito");
                }
                // caja y usuario

                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("----------- [ CLIENTE ] -----------");
                if (Invoice.Customer.Cliente.nombrescliente.Length > MaxCharacters)
                {
                    UseObject.StringBuilderDataIzquierda(Invoice.Customer.Cliente.nombrescliente, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                }
                else
                {
                    Ticket.AddHeaderLine(Invoice.Customer.Cliente.nombrescliente);
                }
                Ticket.AddHeaderLine("IDENT. : " + Invoice.Customer.Cliente.nitcliente);
                Ticket.AddHeaderLine("-----------------------------------");
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("DESCRIP.  CANT.    VENTA      TOTAL");
                Ticket.AddHeaderLine("");
                foreach (Item i in Invoice.Items)
                {
                    if ((i.Code + " " + i.Description).Length > MaxCharacters)
                    {
                        Ticket.AddHeaderLine((i.Code + " " + i.Description).Substring(0, MaxCharacters));
                    }
                    else
                    {
                        Ticket.AddHeaderLine(i.Code + " " + i.Description);
                    }
                    Ticket.AddHeaderLine(UseObject.StringBuilderDetalleProducto(
                        UseObject.InsertSeparatorMil(Math.Round(i.Quantity, 0).ToString().Replace('.', ',')),
                        UseObject.InsertSeparatorMil(Math.Round(i.Neto, 0).ToString().Replace('.', ',')),
                        UseObject.InsertSeparatorMil(Math.Round(i.Total, 0).ToString().Replace('.', ','))));
                    Ticket.AddHeaderLine("");
                }
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("-----------------------------------");
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("         SUBTOTAL :" + UseObject.StringBuilderDetalleTotal(
                    UseObject.InsertSeparatorMil(Math.Round(Invoice.Items.Sum(s => s.SubTotal), 1).ToString().Replace('.', ','))));
                Ticket.AddHeaderLine("              IVA :" + UseObject.StringBuilderDetalleTotal(
                    UseObject.InsertSeparatorMil(
                    Math.Round(Invoice.Items.Sum(s => ((s.UnitPrice * s.Quantity) * s.IVA / 100)), 1).ToString().Replace('.', ','))));
                Ticket.AddHeaderLine("          (02) IC :" + UseObject.StringBuilderDetalleTotal(
                    UseObject.InsertSeparatorMil(
                    Math.Round(Invoice.Items.Sum(s => s.IC * s.Quantity), 1).ToString().Replace('.', ','))));
                Ticket.AddHeaderLine("            TOTAL :" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    Math.Round(Invoice.Items.Sum(s => s.SubTotal) +
                               Invoice.Items.Sum(s => ((s.UnitPrice * s.Quantity) * s.IVA / 100)) +
                               Invoice.Items.Sum(s => s.IC * s.Quantity), 1).ToString().Replace('.', ','))));
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("       RETENCIONES:" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    Math.Round(Invoice.Retentions.Sum(s => s.Value), 1).ToString().Replace('.', ','))));
                Ticket.AddHeaderLine("              NETO:" + UseObject.StringBuilderDetalleTotal(UseObject.InsertSeparatorMil(
                    Math.Round((Invoice.Items.Sum(s => s.SubTotal) +
                                Invoice.Items.Sum(s => ((s.UnitPrice * s.Quantity) * s.IVA / 100)) +
                                Invoice.Items.Sum(s => s.IC * s.Quantity))
                                - Invoice.Retentions.Sum(s => s.Value), 1).ToString().Replace('.', ','))));

                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("----------[ DETALLE IVA ]----------");
                Ticket.AddHeaderLine("GRAVADO          BASE          IVA ");
                //Ticket.AddHeaderLine("  19      2.228.471,70   423.409,62");
                //"19", "2.228.471,70", "423.409,62"

                foreach (
                    var tax in from t in Invoice.Items
                               group t by new { Gravado = t.IVA } into taxs orderby taxs.Key.Gravado 
                               select new
                               {
                                   Gravado = taxs.Key.Gravado,
                                   Base = Math.Round(taxs.Sum(t => t.SubTotal), 1),
                                   Iva = Math.Round(taxs.Sum(t => t.SubTotal * t.IVA / 100), 1)
                               })
                {
                    Ticket.AddHeaderLine(UseObject.TaxDetails(
                        UseObject.InsertSeparatorMil(tax.Gravado.ToString().Replace('.', ',')),
                        UseObject.InsertSeparatorMil(tax.Base.ToString().Replace('.', ',')),
                        UseObject.InsertSeparatorMil(tax.Iva.ToString().Replace('.', ','))));
                }
                if (invoice)
                {
                    Ticket.AddHeaderLine("");
                    Ticket.AddHeaderLine("AUTORIZACIÓN FACTURACION ELECTRONIC");
                    Ticket.AddHeaderLine("No. " + Invoice.Resolution.numero + " VÁLIDA DESDE");
                    Ticket.AddHeaderLine(Invoice.Resolution.date_begin.ToShortDateString() + " HASTA " +
                        Invoice.Resolution.date_end.ToShortDateString());
                    Ticket.AddHeaderLine("RANGO: " + Invoice.Resolution.prefijo + Invoice.Resolution.number_begin +
                        " HASTA " + Invoice.Resolution.prefijo + Invoice.Resolution.number_end);
                    Ticket.AddHeaderLine("");
                    UseObject.StringBuilderDataIzquierda(
                    @"Esta factura es un título valor de acuerdo al art. 774 del C.C. y una vez aceptada declara haber recibido los bienes y servicios a satisfacción.", MaxCharacters).
                        ForEach((data) => Ticket.AddHeaderLine(data));
                    Ticket.AddHeaderLine("");
                    Ticket.AddHeaderLine("Representación Gráfica de ");
                    Ticket.AddHeaderLine("la Factura de Venta Electrónica.");
                    Ticket.AddHeaderLine("");
                }
                Ticket.AddHeaderLine("");
                UseObject.StringBuilderDataCenter("SOFTWARE DFPYME", MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                UseObject.StringBuilderDataCenter("comercial@intredete.com", MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("*GRACIAS POR SER NUESTROS CLIENTES*");
                Ticket.AddHeaderLine("");
                
                //DTO.Clases.ElColor c = new DTO.Clases.ElColor();
                //Ticket.HeaderImage = c.ImagenBit;

                /*
                var color = new DTO.Clases.ElColor
                {
                    MapaBits =
                        @"iVBORw0KGgoAAAANSUhEUgAAAUAAAAFACAYAAADNkKWqAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAO3UlEQVR4nO3d2XLcMA4FUGdq/v+XPS+TKperHavFBZfCOc/pFrU0HAIi8efz8/PzA6Ch/1QPAKCKAAi0JQACbQmAQFsCINCWAAi0JQACbQmAQFsCINCWAAi0JQACbQmAQFsCINCWAAi0JQACbQmAQFsCINCWAAi0JQACbQmAQFsCINCWAAi0JQACbQmAQFsCINCWAAi09d+dB/vz58/Ow/3q8/Pz13/z05ivfHa2q2OZPeZ37tvsY4zco9muXueq4+64v6vt/l35HyDQlgAItCUAAm0JgEBbW4sg6ZKSwUljecercVcUjDpy7d8XEQBX36TRYNL9Ibp6/lVB+9X4kqr3P0kayyvpv8sZTIGBtgRAoC0BEGgrIgf4XVrO7up4Vr+x/5OZuZTR1SYjxxj9t3fsON8RCXmyv9J+lzNEBsAq7yTTVxsdS+LD9puUoPOOqj96J16rRKbAQFsCINCWAAi0JQf4xWge5e7nV+SN7hZuVrg6lh15rNljmf3vZr90bnXIvwmAF4wknGc+bDtWZOz6cdwtHoxc+10V35nfN7LKRWHkd6bAQFsCINCWAAi0JQd4wY6VFiP/dkexZLYTCyM7JI2lAwHwi8qVIFWJ8xGnJd1XFBSu/PGpeq5Ue39nCgy0JQACbQmAQFtygF+syMtUJfGTVnhU2XFd0q8B/xYZAE9I3latDtlReLgyvh3nO1J4mH1dVhQyZl+X1U74Xb7LFBhoSwAE2hIAgbYicoAnJpLTV4dUjW/k+3bkxJK3kdp1XdL7PO8UEQDTpW+rlD6+Kq4LvzEFBtoSAIG2BECgLTnAC3YVAVYf9ymq+nVc5f6eY2sATH+TfGS7pNnHnr390si/m63yOaja5qqigXr6c5DAFBhoSwAE2hIAgba25gBP3F7+qrTeGim9jN899mpp92n1Mapepq/Ied6hCnzBzO2rdhxztqSxfHyct43UT9Kua0emwEBbAiDQlgAItCUHeMNILmlX0nj2GLvlq0YKCiPHeCWp8f3q79v9nLUIgFWNwneobOZ+VUUPj0qrz3f0j2BFM/fU59QUGGhLAATaEgCBtlrkAHclqxNyGonSE/GrnVAsuXvMdz6fWEiLCIBVvRuqxjJzS6t3rF6elJro/irpR5hSLOnMFBhoSwAE2hIAgbYicoBJUgoeK3KPs8/txP63SasvKq5X5bZUic/H0T1BRnoejBQtEm/kd8mFpVd2FJtmn9uKniCzP1vllDGbAgNtCYBAWwIg0FZET5DZWzxVbVuU9P1P7oNSoXJ7sh3Sx7eKKvBNKcWDHdsWvVJVTRw537SVKunbp61uIp/AFBhoSwAE2hIAgbYicoAnJmBX9AW5+++S8itJ2yDtuEcjKq7VrpVDd19+1xPk/2ZeiLTk9yspRRV+NnL9Zt7fyvt4ygqPq0yBgbYEQKAtARBoKzYHeNepOYluWyPdlXR/O662uTuetPP4KyIAJv/gRs1OGj/5Wu2QUmw64T6u7iEz+tkZTIGBtgRAoC0BEGgrIgf45B4Uq614s3/W52Z8X9I9ThpLkpEVHd8/++iVILtWZOzoQfGU5uFJCeykP3BJY7kqeSuyVKbAQFsCINCWAAi0FVEEuWpHEj+5qfUOlVtIPeWaVu30cqUYsas/9Cn3sjwAVvagSGoeftdIj4fR44xYXWza0QS96rhJz9/Hx54VI6uYAgNtCYBAWwIg0FZ5DnC2U1cZXDW7SDGS26rI6exKzlf1Y6ladZPS4+bRK0FGjF6Yiq190hP7uyQmv083strp7jHe+b7kwuFXpsBAWwIg0JYACLS1NQc4khOrejO9qqiyK2eSkvw+lXOb/9mdjimCrLAjOV9xjB19R1asmjntfqSd28xj7gpg1QUyU2CgLQEQaEsABNqKyAE+ZZXB1e98yuqB1Xbdj1dWv8i74qXimbnbXVr1BBmxa9unETN/NKPbIKVs9bXiXpyyyqCzHW92zGAKDLQlAAJtCYBAW7E5wNlbNyWrTPavvlaV55Ykfczp41slNgBesaJfwupCxgo7Ch7phaWUYs6OVTizvz/9mq5kCgy0JQACbQmAQFtH5QBTVoz85MmJ5Cef2ytJPUFSVmk80dYAWNnkuaqxd8X3XT3XpMT+0xuKz7wGq5/lf43laatwTIGBtgRAoC0BEGgroidI1bFP2DL8iivndsJLzyOq7seO4+44xux8cFU+812xVeDqC3NHUvP1mdIKCiOqeoJckXSduxRGTIGBtgRAoC0BEGgrNgf43Y7t73c1X0962/+VpC2yqsay+n6k58l2jU9PkMmSAskOo+ebVC0+LZme9qyljCepmPMbU2CgLQEQaEsABNo6PgeYmlvYZTSJP/P67SoipUgbb9JqmJR85G8iAuApF+urit4Nu6QXI058Xq66e25p9+i71HtmCgy0JQACbQmAQFsROcAn2LUl/lObw79j9vZfV4+xw8kFhX9J3R6rvCdI0nFODBoj2xbt8uT7MdLrY3UfmNnPwQn3412mwEBbAiDQlgAItBXRE6Rq66EnJJffkZKIftL9SOoJMju395SeOf+iCrzY3UR3UjBIGsvHx9yeKiNmbx120jZSdySuMDIFBtoSAIG2BECgrYgcYEIuYJW751bZg/W0POXINUgqyJy6euWqxPFFBMDVUn6of+0Yz92ldVWN1k8+zmqr79HsvjKvJP2h+coUGGhLAATaEgCBth6ZA0xMtv7LikbhSddg9lgqrsGKAkVV/iup8X21o7fDOulCr5T4hv1urkH+NagueLxiCgy0JQACbQmAQFsR22FdlZRDSMuvdFdVaEk/xg4zi1KP7glSaeRt9dXHnX3TV2yrNHs7px0rVXYUBSr6a1w95or9/JJXGN1hCgy0JQACbQmAQFttcoBJja6v2pFvmb1dV5KqQkZVk/akXVlOeD4+PkJXgozc8MoLf0ri9zc7ijIzv2t2b46rdhSW0p+hHQ3ZVzIFBtoSAIG2BECgraOLIGn5kSds+7Ti+5O2pbr6fYn5qt+MbLk18qyNHKP6Oh8dAH8yO7m8urpWubphdcGjqkCx4vvuShnHx8ea1Tojx6hmCgy0JQACbQmAQFsR22HNTtTO+ty/Pl+xC8gOSeNLum+jx30laSzpx1glsgiyK4n6hJUbVdcq/ftOvJfvqCiGJa3CmcUUGGhLAATaEgCBtiJzgKOS8j8n9qq4etyZeahdq01SVteMHnPHc1WxRZaeID8YrRRX9OaYfZwdP8q0t/if2hNkl5ReOEn/KfnKFBhoSwAE2hIAgbaOyQHuWkWyI3exo4/EzLG889kkKT1BKlVtX5X+bPx1TAA8QXrCuWp7o5kFqKTVCLPv5exC3477m3Q/7jAFBtoSAIG2BECgreNzgEnJ1vSk8YmrIFbniHY1m7+bp11h9oqd6jzeiMjG6DuOXRU403oypK+0SJd8DWYXKJL2OZzFFBhoSwAE2hIAgbbKiyC7ksEpBYAVWx6dlpiu3PZpth3bcFU1Hl895oTntjwAjprZtPyEN9irEtM7thNLvh8rCktJBZSksexkCgy0JQACbQmAQFvH5wCrVl+k50gqXlrd1ddjx/cnrczZIWksO5UHwB3bII0ksF958sNS1RelcmnYiB0Nxe8cc8ZYVhdGEu6tKTDQlgAItCUAAm1tzQE+ZevySic2xB6R1D/llR3FpqR+NledsnNMeRHkRLOLKledulVV9UP+Vcof1qR9Ij8+aoo5CUyBgbYEQKAtARBoKzYHmJJb2FF0+PjIytnNLjzsuoYnSX/xe9c1/n6cltthdXjjfJbZ5zL72nfqMXLqc7Vj3KfcS1NgoC0BEGhLAATaisgBViXJT8lT/EtaT5X0Y1w95hOejZ+kr/7Zqbwx+gkP4MyxjGz/lWZmn5Ck/h+7JK++WF1sS2EKDLQlAAJtCYBAWxFFkFeSks47eofM3iI+uaCw6jgzj5t0/XZ8fnVeO3XlS3kAXJHkPa1p+cxjjh63+oH8rmKV0JMKMknFxESmwEBbAiDQlgAItBXbE2THcZLyN1W5mburAk7IJe3oJ3LiszbbCc/CT8qLID9JSt7eHctoxfbJP5oTPWHbttlFn9MLRqbAQFsCINCWAAi09edz48T85GTpFXdXc5ywbfzq3E+3Z2PEk6/9o3uCJL11PxqcEhO6X60OxpVNstP/0KQ/G98lL69czRQYaEsABNoSAIG2Yl+EfmXHqoW7eY60/MjV8ZzY6yPp3GYf98ReLicrD4CdE7B/jTz0T9pObMSOwgjXnXKdTYGBtgRAoC0BEGirPAd4qtn9F5L6Kpy4xVNVoWU2Tcv3OiYAzi4UvJKaqJ2lalnU3Xt3QiEjpQ/MK7P/YD7x92EKDLQlAAJtCYBAW4/sCXJVUnK5UyPuE5u+/yRpJc3qXOuM70xzTBGEfU7bQ27Erh+5wsNr1f8JMQUG2hIAgbYEQKAtOcAHmL091NPzTqk6Xvfv5/zoniA/WX3SVY3MR6pru1ZBJK9kuPr5qr4t1Qn8WVacxymFNFNgoC0BEGhLAATaisgBfle1pfuunES3LY+SeoIk7SRTpeM5/yQyAHLdOz1BrgTZke/rti3VCk/+Q/hdwrmaAgNtCYBAWwIg0JYcYIgTV2kkjeWq9DGPFG4ScmqnEQAvqFp9kZLYH22+ftr5viP53GYXyJ7IFBhoSwAE2hIAgbbkACdK35aqquH5jvNNamT+lGPsyFtW5x4FwBtWrJYYedgUD+4fd8TsFTfvHOOu0YLW05gCA20JgEBbAiDQlhzgBenbV1UVS3ZYPZaqF4NXnNeu1g8z6QnyQlJwuerqmEf+Xdrqi6r7lFL0OfE5faVqxUjCH1pTYKAtARBoSwAE2orIASbkAkal7bLxhGv6k5QVI6de4x3X75T8aEQAJF9Kk/EVzearzB7zadcgIUiaAgNtCYBAWwIg0Nafz4SJOEAB/wME2hIAgbYEQKAtARBoSwAE2hIAgbYEQKAtARBoSwAE2hIAgbYEQKAtARBoSwAE2hIAgbYEQKAtARBoSwAE2hIAgbYEQKAtARBoSwAE2hIAgbYEQKAtARBoSwAE2hIAgbYEQKCt/wH1wml2Htt/kAAAAABJRU5ErkJggg=="
                };
                */


                /*
                @"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";

                */
                /*var color = new DTO.Clases.ElColor { MapaBits = 
                @"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"
                };
                 * */


                //Ticket.HeaderImage = new System.Drawing.Bitmap(color.ImagenBit, new System.Drawing.Size(220, 220));

                Ticket.PrintTicket("");

                ///miTicket.AddHeaderLine("AUTORIZACIÓN FACTURACION ELECTRONIC");
                ///miTicket.AddHeaderLine("No. 18764029549683 VÁLIDA DESDE ");
                ///miTicket.AddHeaderLine("2020-01-01 HASTA 2022-12-31 ");
                ///miTicket.AddHeaderLine("RANGO: TCFA28521 A TCFA28620 ");
                    


                    /*
                TotalInvoice.SubTotal = Document.Items.Sum(s => s.SubTotal);
                TotalInvoice.IVA = Math.Round(Document.Items.Sum(s => ((s.UnitPrice * s.Quantity) * s.IVA / 100)), 2);
                TotalInvoice.IC = Math.Round(Document.Items.Sum(s => s.IC * s.Quantity), 2);
                TotalInvoice.Total = TotalInvoice.SubTotal + TotalInvoice.IVA + TotalInvoice.IC;
                //Math.Round(Document.Items.Sum(s => s.Total), 2);
                TotalInvoice.Retention = Math.Round(Document.Retentions.Sum(s => s.Value), 2);
                TotalInvoice.Neto = TotalInvoice.Total - TotalInvoice.Retention;*/



                //Ticket.AddHeaderLine("-----------------------------------");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void PrintPayments(ElectronicDocument Invoice, ElectronicPayment payment)
        {
            try
            {
                UseObject.StringBuilderDataCenter(Invoice.Company.Company.nombrecomercialempresa, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                
                UseObject.StringBuilderDataCenter("NIT: " + Invoice.Company.Company.nitempresa + "-" + Invoice.Company.Company.dv, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                UseObject.StringBuilderDataCenter(
                    Invoice.Company.Company.direccionempresa + " " +
                    Invoice.Company.City.Name + " " +
                    Invoice.Company.City.Departament.Name, MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                Ticket.AddHeaderLine("");
                UseObject.StringBuilderDataCenter("COMPROBANTE DE PAGO", MaxCharacters).
                    ForEach((data) => Ticket.AddHeaderLine(data));
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("Fecha: " + payment.Date.ToShortDateString() + " " +
                    payment.Date.TimeOfDay.Hours + ":" + payment.Date.TimeOfDay.Minutes);
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("No. factura:   " + Invoice.Numero);
                Ticket.AddHeaderLine("Valor factura: " + UseObject.InsertSeparatorMil(Invoice.Neto.ToString().Replace('.', ',')));
                Ticket.AddHeaderLine("Valor pago:    " + UseObject.InsertSeparatorMil(payment.Payments.Sum(s => s.Valor).ToString().Replace('.', ',')));
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("Medios de pago");
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("Efectivo:      " + UseObject.InsertSeparatorMil(payment.Payments.Where
                    (p => p.Code.Equals("10")).Sum(s => s.Valor).ToString().Replace('.', ',')));
                Ticket.AddHeaderLine("-----------------------------------");
                Ticket.AddHeaderLine("Transferencia: " + UseObject.InsertSeparatorMil(payment.Payments.Where
                    (p => p.Code.Equals("31")).Sum(s => s.Valor).ToString().Replace('.', ',')));
                Ticket.AddHeaderLine("Tarjeta:       " + UseObject.InsertSeparatorMil(payment.Payments.Where
                    (p => p.Code.Equals("49")).Sum(s => s.Valor).ToString().Replace('.', ',')));
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("TOTAL BANCOS:  " + UseObject.InsertSeparatorMil(
                    payment.Payments.Where(p => p.Code.Equals("31") || p.Code.Equals("49")).Sum(s => s.Valor).ToString().Replace('.', ',')));
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("");
                Ticket.AddHeaderLine("___________________________________");
                Ticket.AddHeaderLine("FIRMA");
                Ticket.AddHeaderLine("___________________________________");
                Ticket.AddHeaderLine("CEDULA");
                Ticket.AddHeaderLine("___________________________________");
                Ticket.AddHeaderLine("TELEFONO");

                Ticket.PrintTicket("");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}