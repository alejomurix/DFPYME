using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing;

namespace Aplicacion.Ventas.Factura
{
    public class Imprimir
    {
        public LocalReport Report { set; get; }

        private int m_currentPageIndex;

        private IList<Stream> m_streams;

        private Stream CreateStream(string name,
            string fileNameExtension, Encoding encoding,
            string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
                @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>8.5</PageWidth>
                        <PageHeight>10</PageHeight>
                        <MarginTop>0.07</MarginTop>
                        <MarginLeft></MarginLeft>
                        <MarginRight></MarginRight>
                        <MarginBottom>4.8in</MarginBottom>
                  </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
                Metafile(m_streams[m_currentPageIndex]);

            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            ev.Graphics.DrawImage(pageImage, adjustedRect);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public void Print()
        {
            Export(this.Report);
            
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Ocurrió un error");
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = "HP LaserJet Professional M1212nf MFP";
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Ocurrió un error con la impresora.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
    }
}