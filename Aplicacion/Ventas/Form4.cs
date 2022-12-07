using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace Aplicacion.Ventas
{
    public partial class Form4 : Form
    {
        private BussinesLayer.Clases.BussinesDevolucion miBussDevol;
        public Form4()
        {
            InitializeComponent();
            this.miBussDevol = new BussinesLayer.Clases.BussinesDevolucion();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                //this.miBussDevol.IvaDevoluciones(2, new DateTime(2018, 05, 17));
            }
            catch { }
            /*Ticket ticket = new Ticket();
            ticket.UseItem = false;

            //ticket.AddHeaderLine("===================================");
            //ticket.AddHeaderLine("-----------------------------------");
            ticket.AddHeaderLine("-----------------------------------------");
            ticket.AddHeaderLine("         SUPERMERCADO LA REMESA         -");
            //ticket.AddHeaderLine("-----------------------------------------");

            ticket.PrintTicket("Microsoft XPS Document Writer");*/


            /*this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.ReportPath =
            @"C:\Users\alejo_cq\Documents\Visual Studio 2010\Projects\DFPYME\Aplicacion\Informes\RptTicket.rdlc";
            this.reportViewer1.RefreshReport();*/

            /*Utilities.Imprimir print = new Utilities.Imprimir();
            print.Report = this.reportViewer1.LocalReport;
            print.Print(Utilities.Imprimir.TamanioPapel.Ticket);*/
        }
    }
}