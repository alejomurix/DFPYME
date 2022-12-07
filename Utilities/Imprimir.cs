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

namespace Utilities
{
    public class Imprimir
    {
        public LocalReport Report { set; get; }

        //public bool Carta { set; get; }

        public enum TamanioPapel
        {
            MediaCarta,

            Carta,

            CartaHorizontal,

            Ticket
        };

        private int m_currentPageIndex;

        private IList<Stream> m_streams;

        public Imprimir()
        {
        }

        private Stream CreateStream(string name,
            string fileNameExtension, Encoding encoding,
            string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report, TamanioPapel tamanio)
        {
            string deviceInfo = "";
            switch (tamanio)
            {
                case TamanioPapel.MediaCarta:
                    {
                        deviceInfo =
                        @"<DeviceInfo>
                                <OutputFormat>EMF</OutputFormat>
                                <PageWidth>8.5</PageWidth>
                                <PageHeight>9.3</PageHeight>
                                <MarginTop>0.07</MarginTop>
                                <MarginLeft></MarginLeft>
                                <MarginRight></MarginRight>
                                <MarginBottom>4.8in</MarginBottom>
                            </DeviceInfo>";
                        break;
                    }
                case TamanioPapel.Carta:
                    {
                        deviceInfo =
                       @"<DeviceInfo>
                                <OutputFormat>EMF</OutputFormat>
                                <PageWidth>8.5</PageWidth>
                                <PageHeight>11</PageHeight>
                                <MarginTop>0.5</MarginTop>
                                <MarginLeft></MarginLeft>
                                <MarginRight></MarginRight>
                                <MarginBottom></MarginBottom>
                          </DeviceInfo>";
                        break;
                    }
                case TamanioPapel.CartaHorizontal:
                    {
                        deviceInfo =
                       @"<DeviceInfo>
                                <OutputFormat>EMF</OutputFormat>
                                <PageWidth>11</PageWidth>
                                <PageHeight>11</PageHeight>
                                <MarginTop>0.07</MarginTop>
                                <MarginLeft></MarginLeft>
                                <MarginRight></MarginRight>
                                <MarginBottom></MarginBottom>
                          </DeviceInfo>";
                        break;
                    }
                case TamanioPapel.Ticket:
                    {
                        deviceInfo =
                       @"<DeviceInfo>
                                <OutputFormat>EMF</OutputFormat>
                                <PageWidth>0.6</PageWidth>
                                <PageHeight></PageHeight>
                                <MarginTop>0.07</MarginTop>
                                <MarginLeft></MarginLeft>
                                <MarginRight></MarginRight>
                                <MarginBottom></MarginBottom>
                          </DeviceInfo>";
                        break;
                    }
            }

            /*if (Carta)
            {
                deviceInfo =
                @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>11</PageWidth>
                        <PageHeight>11</PageHeight>
                        <MarginTop>0.07</MarginTop>
                        <MarginLeft></MarginLeft>
                        <MarginRight></MarginRight>
                        <MarginBottom></MarginBottom>
                  </DeviceInfo>";
            }
            else
            {
                deviceInfo =
                @"<DeviceInfo>
                        <OutputFormat>EMF</OutputFormat>
                        <PageWidth>8.5</PageWidth>
                        <PageHeight>10</PageHeight>
                        <MarginTop>0.07</MarginTop>
                        <MarginLeft></MarginLeft>
                        <MarginRight></MarginRight>
                        <MarginBottom>4.8in</MarginBottom>
                  </DeviceInfo>";
            }*/
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            deviceInfo = null;

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
            //ev.PageSettings.PaperSize = 

            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            ev.Graphics.DrawImage(pageImage, adjustedRect);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public void Print(TamanioPapel tamanio)
        {
            try
            {
                Export(this.Report, tamanio);

                if (m_streams == null || m_streams.Count == 0)
                    throw new Exception("Ocurrió un error");
                PrintDocument printDoc = new PrintDocument();
                if (tamanio.Equals(TamanioPapel.CartaHorizontal))
                {
                    printDoc.DefaultPageSettings.Landscape = true;
                }
                //printDoc.PrinterSettings.PrinterName = "HP LaserJet Professional M1212nf MFP";
                ///printDoc.PrinterSettings.PrinterName = "HP";
                printDoc.PrinterSettings.PrinterName = "Microsoft XPS Document Writer";
                
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
                printDoc = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}