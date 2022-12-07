using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DataAccessLayer.DataSets;
using DataAccessLayer.Models;
using DataAccessLayer.Standard;
using Utilities;

namespace DataAccessLayer.Generator
{
    public class DocumentElectronicLoad
    {
        public ElectronicDocument Document { set; get; }

        private InvoiceType InvoiceType { set; get; }

        public DocumentElectronicLoad()
        {
            this.InvoiceType = new InvoiceType();
        }


        public string CreateXML(string number)
        {
            LoadHeader();
            LoadEmisor();
            LoadAdquiriente();
            LoadResolution();
            LoadPayMethod();
            LoadTotal();
            LoadTotalImpuesto(false); // Carga impuestos;  true : Carga retenciones
            LoadItem();

            XmlSerializer xmlSerialize = new XmlSerializer(typeof(InvoiceType));
            Stream str = new FileStream("/xmlDocumnets/DIAN_" + number + ".xml", FileMode.Create, FileAccess.Write);
            xmlSerialize.Serialize(str, this.InvoiceType);
            str.Close();

            string xmlBase64 = "";
            using (var ms = new MemoryStream())
            {
                xmlSerialize.Serialize(ms, this.InvoiceType);
                xmlBase64 = Convert.ToBase64String(ms.ToArray());
            }
            return xmlBase64;
        }


        private void LoadHeader()
        {
            InvoiceType.Heading = new Heading();
            InvoiceType.Heading.Document = this.Document.Tipo; // Header.Tipo;
            InvoiceType.Heading.NITEmisor = this.Document.Company.Company.nitempresa; // Emisor.NIT;
            InvoiceType.Heading.NITCliente = this.Document.Customer.Cliente.nitcliente; // Customer.NIT;
            InvoiceType.Heading.UBL = this.Document.VUBL; // Header.UBL;
            InvoiceType.Heading.Version = this.Document.VDIAN; // Header.Version;
            InvoiceType.Heading.Numero = this.Document.Numero; // Header.Number;
            InvoiceType.Heading.Fecha = UseDate.DateToStringYMD(this.Document.Fecha); // Header.Date;
            InvoiceType.Heading.Hora = UseDate.TimeToString00(this.Document.Fecha) + "-05:00"; // Header.Hour;
            InvoiceType.Heading.DateEnd = UseDate.DateToStringYMD(this.Document.FechaLimite); // Header.DateEnd;
            InvoiceType.Heading.Tipo = this.Document.TipoFactura; // Header.Type_Invoice;
            InvoiceType.Heading.CodMoneda = this.Document.Moneda; // Header.Moneda;
            InvoiceType.Heading.NoItems = this.Document.NoItems.ToString(); // Header.NumberItems.ToString();
            InvoiceType.Heading.CodAmbiente = this.Document.TipoAmbiente; // Header.CodeEnvironment.ToString();
            InvoiceType.Heading.TipoOperation = this.Document.TipoOperacion; // Header.TypeOperation;
        }

        private string DateString(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }

        private string TimeString(DateTime date)
        {
            return date.Hour + ":" + date.Minute + ":" + date.Second + "-05:00";
        }

        private void LoadEmisor()
        {
            InvoiceType.Emisor = new Standard.Emisor
            {
                Tipo = this.Document.Company.Company.type_person.ToString(), //Emisor.Type_,
                NIT = this.Document.Company.Company.nitempresa, //Emisor.NIT,
                TipoIdentify = this.Document.Company.Company.type_document, //Emisor.TypeIdentify,
                Regimen = this.Document.Company.Company.idregimen, //Emisor.Regimen,
                RazonSocial = this.Document.Company.Company.nombrejuridicoempresa, //Emisor.RazonSocial,
                NameComercial = this.Document.Company.Company.nombrecomercialempresa, //Emisor.Comercial,
                Direccion = this.Document.Company.Company.direccionempresa, //Emisor.Direccion,
                CodDepartamento = this.Document.Company.City.Departament.Code, // Emisor.City.Departament.Code,
                Ciudad = this.Document.Company.City.Name, // Emisor.City.Name,
                CodPostal = this.Document.Company.City.CodePostal, // Emisor.City.CodePostal,
                CodPais = this.Document.Company.City.Departament.Country.Code, // Emisor.City.Departament.Country.Code,
                Departamento = this.Document.Company.City.Departament.Name, // Emisor.City.Departament.Name,
                Pais = this.Document.Company.City.Departament.Country.Name, //Emisor.City.Departament.Country.Name,
                DV = this.Document.Company.Company.dv, //Emisor.DV,
                CodMunicipio = this.Document.Company.City.Code, // Emisor.City.Code,
                NameRUT = this.Document.Company.Company.nombrejuridicoempresa, // Emisor.RazonSocial,
                Tributary = new Tributary { Code = InfoRUTString(this.Document.Company.DetailsRUT)  /*Emisor.InfoTributary*/ },
                AddressEmisor = new AddressEmisor
                {
                    Pais = this.Document.Company.City.Departament.Country.Name, //Emisor.City.Departament.Country.Name,
                    CodPais = this.Document.Company.City.Departament.Country.Code, //Emisor.City.Departament.Country.Code,
                    Departamento = this.Document.Company.City.Departament.Name, //Emisor.City.Departament.Name,
                    CodDepartamento = this.Document.Company.City.Departament.Code, // Emisor.City.Departament.Code,
                    Ciudad = this.Document.Company.City.Name, // Emisor.City.Name,
                    CodMunicipio = this.Document.Company.City.Code, //Emisor.City.Code,
                    CodigoPostal = this.Document.Company.City.CodePostal, // Emisor.City.CodePostal,
                    Direccion = this.Document.Company.Company.direccionempresa, // Emisor.Direccion
                },
                CIIU = CIIUString(this.Document.Company.DetailsCIIU), //  Emisor.CIIU,
                CommerceInformation = new CommerceInformation { PrefijoFactura = this.Document.Resolution.prefijo /*Resolution.Prefijo*/ },
                ContactoEmisor = new ContactoEmisor
                {
                    Tipo = 1, // Emisor.Contact.IDType,
                    Nombre = this.Document.Company.Company.nombrejuridicoempresa, // Emisor.Contact.Name,
                    Telefono = this.Document.Company.Company.celularempresa, // Emisor.Contact.Phone,
                    Email = this.Document.Company.Company.emailempresa // Emisor.Contact.Email
                }
                /*,
                GrupoTributo = new GrupoTributo
                {
                    Codigo = Emisor.IdentifyTax.Code,
                    Nombre = Emisor.IdentifyTax.Description
                }*/
            };
            DataBaseDS.details_tributary_empresaRow tRow = this.Document.Company.DetailsTributary.FirstOrDefault();
            InvoiceType.Emisor.GrupoTributo = new GrupoTributo
            {
                Codigo = tRow.codigo,
                Nombre = tRow.nombre
            };
        }

        private string InfoRUTString(DataBaseDS.details_rut_empresaDataTable tRUT)
        {
            string info = "";
            int cont = 1;
            foreach (DataBaseDS.details_rut_empresaRow row in tRUT.Rows)
            {
                info += row.codigo;
                if (tRUT.Rows.Count > cont)
                {
                    info += ";";
                }
                cont++;
            }
            return info;
        }

        private string CIIUString(DataBaseDS.empresa_ciiuDataTable tCIIU)
        {
            string info = "";
            int cont = 1;
            foreach (DataBaseDS.empresa_ciiuRow row in tCIIU.Rows)
            {
                info += row.codigo;
                if (tCIIU.Rows.Count > cont)
                {
                    info += ";";
                }
                cont++;
            }
            return info;
        }

        private void LoadAdquiriente()
        {
            InvoiceType.Adquiriente = new Adquiriente
            {
                Tipo = this.Document.Customer.Cliente.type_person.ToString(), // Customer.Type_,
                NIT = this.Document.Customer.Cliente.nitcliente, // Customer.NIT,
                Identify = this.Document.Customer.Cliente.type_document, // Customer.TypeIdentify,
                Regimen = this.Document.Customer.Cliente.idregimen, // Customer.Regimen,
                RazonSocial = this.Document.Customer.Cliente.nombrescliente, // Customer.RazonSocial,
                //NameComercial = this.Document.Customer.Cliente.name_comercial, // Customer.Comercial,
                Direccion = this.Document.Customer.Cliente.direccioncliente, // Customer.Direccion,
                CodDepartamento = this.Document.Customer.City.Departament.Code, // Customer.City.Departament.Code,
                Ciudad =  this.Document.Customer.City.Name, // Customer.City.Name,
                CodPostal =  this.Document.Customer.City.CodePostal, // Customer.City.CodePostal,
                CodPais = this.Document.Customer.City.Departament.Country.Code, //  Customer.City.Departament.Country.Code,
                Departamento =  this.Document.Customer.City.Departament.Name, //  Customer.City.Departament.Name,
                Pais = this.Document.Customer.City.Departament.Country.Name, //  Customer.City.Departament.Country.Name,
                DV = this.Document.Customer.Cliente.dv, // Customer.DV,
                CodMunicipio = this.Document.Customer.City.Code, //  Customer.City.Code,
                TributaryADQ = new TributaryADQ { Codigo = InfoRUTString(this.Document.Customer.DetailsRUT) /*Customer.InfoTributary*/ },
                InformacionLegal = new InformacionLegal
                {
                    NameRUT = this.Document.Customer.Cliente.nombrescliente, // Customer.RazonSocial,
                    NIT = this.Document.Customer.Cliente.nitcliente, // Customer.NIT,
                    TypeIdentify = this.Document.Customer.Cliente.type_document, // Customer.TypeIdentify,
                    DV = this.Document.Customer.Cliente.dv, //Customer.DV
                },
                AddressAdquiriente = new AddressAdquiriente
                {
                    Pais = this.Document.Customer.City.Departament.Country.Name, // Customer.City.Departament.Country.Name,
                    CodigoPais = this.Document.Customer.City.Departament.Country.Code, // Customer.City.Departament.Country.Code,
                    Departamento = this.Document.Customer.City.Departament.Name, // Customer.City.Departament.Name,
                    CodDepartamento = this.Document.Customer.City.Departament.Code, // Customer.City.Departament.Code,
                    Ciudad = this.Document.Customer.City.Name, // Customer.City.Name,
                    CodMunicipio = this.Document.Customer.City.Code, //  Customer.City.Code,
                    CodigoPostal = this.Document.Customer.City.CodePostal, //  Customer.City.CodePostal,
                    Direccion = this.Document.Customer.Cliente.direccioncliente, // Customer.Direccion
                },
                ContactoAdquiriente = new ContactoAdquiriente
                {
                    Tipo = 1, // Customer.Contact.IDType,
                    Nombre = this.Document.Customer.Cliente.nombrescliente, //  Customer.Contact.Name,
                    Telefono = this.Document.Customer.Cliente.celularcliente, //  Customer.Contact.Phone,
                    Email = this.Document.Customer.Cliente.emailcliente, //  Customer.Contact.Email
                },
                /*GrupoTributoAdquiriente = new GrupoTributoAdquiriente
                {
                    Codigo = Customer.IdentifyTax.Code,
                    Nombre = Customer.IdentifyTax.Description
                }*/
            };
            if (InvoiceType.Adquiriente.Tipo.Equals("2")) // persona natural
            {
                InvoiceType.Adquiriente.Name = this.Document.Customer.Cliente.name;
                InvoiceType.Adquiriente.LastName = this.Document.Customer.Cliente.last_name;
            }
            if (!String.IsNullOrEmpty(this.Document.Customer.Cliente.name_comercial))
            {
                InvoiceType.Adquiriente.NameComercial = this.Document.Customer.Cliente.name_comercial;
            }
            /*if (InvoiceType.Adquiriente.Tipo.Equals("1") && String.IsNullOrEmpty(InvoiceType.Adquiriente.NameComercial))
            {
                InvoiceType.Adquiriente.NameComercial = InvoiceType.Adquiriente.RazonSocial;
            }*/
            DataBaseDS.details_tributary_clientRow cRow = this.Document.Customer.DetailsTributary.FirstOrDefault();
            InvoiceType.Adquiriente.GrupoTributoAdquiriente = new GrupoTributoAdquiriente
            {
                Codigo = cRow.codigo,
                Nombre = cRow.nombre
            };
                
        }

        private string InfoRUTString(DataBaseDS.details_rut_clientDataTable tRUT)
        {
            string info = "";
            int cont = 1;
            foreach (DataBaseDS.details_rut_clientRow row in tRUT.Rows)
            {
                info += row.codigo;
                if (tRUT.Rows.Count > cont)
                {
                    info += ";";
                }
                cont++;
            }
            return info;
        }

        private void LoadResolution()
        {
            InvoiceType.Resolucion = new Resolucion
            {
                Number = this.Document.Resolution.numero, // Resolution.Number,
                DateBegin = UseDate.DateToStringYMD(this.Document.Resolution.date_begin), //  Resolution.DateBegin.Year + "-" + Resolution.DateBegin.Month + "-" + Resolution.DateBegin.Day,
                DateEnd = UseDate.DateToStringYMD(this.Document.Resolution.date_end), //  Resolution.DateEnd.Year + "-" + Resolution.DateEnd.Month + "-" + Resolution.DateEnd.Day,
                Prefijo = this.Document.Resolution.prefijo, // Resolution.Prefijo,
                NumberBegin = this.Document.Resolution.number_begin, // Resolution.NumberBegin,
                NumberEnd = this.Document.Resolution.number_end, // Resolution.NumberEnd
            };
        }

        private void LoadPayMethod()
        {
            InvoiceType.MetodoPago = new MetodoPago
            {
                CodMedio = this.Document.MedioPago, // Payment.CodMeans,
                CodMetodo = this.Document.MetodoPago, // Payment.IDMethod,
                Date = UseDate.DateToStringYMD(this.Document.FechaPago), // Payment.Date
            };
        }

        private void LoadTotal()
        {
            InvoiceType.Total = new Standard.Total();
            InvoiceType.Total.Base = Math.Round(this.Document.Items.Sum(s => s.SubTotal), 2);  // TOT_1
            InvoiceType.Total.MonedaBase = this.Document.Moneda;

            // validacion si solo se suman las bases de los items con impuesto
            InvoiceType.Total.BaseImponible = Math.Round(this.Document.Items.
                                                    Where(i => i.Taxes.Count() > 0).
                                                    Sum(s => s.SubTotal), 2);
            /**
            InvoiceType.Total.BaseImponible = Items.Where(i => i.Taxes.Count() > 0).
                Sum(s => s.Taxes.Sum(t => t.Base));
            */

            InvoiceType.Total.MonedaBaseImponible = this.Document.Moneda;

            InvoiceType.Total.ValorPago = Math.Round(InvoiceType.Total.Base +
                this.Document.Items.Where(i => i.Taxes.Count() > 0).Sum(s => s.Taxes.Sum(t => t.Value)) , 2);

            InvoiceType.Total.MonedaValor = this.Document.Moneda;
            InvoiceType.Total.ValorTotal = InvoiceType.Total.ValorPago;
            InvoiceType.Total.MonedaTotal = this.Document.Moneda;
        }

        private void LoadTotalImpuesto(bool stateTax)
        {
            
            // añadir validacion si existen impuestos y retenciones 
            List<Impuesto> Impuestos = new List<Impuesto>();
            InvoiceType.TotalImpuestos = new List<TotalImpuesto>();

            //if (stateTax)
            //{
                List<Tax> taxes = new List<Tax>();
                foreach (var item in this.Document.Items)
                {
                    taxes.AddRange(item.Taxes);
                }

                foreach (var tax in
                    from t in taxes.Where(t => t.State.Equals(stateTax) && t.ID.Equals("01"))
                    group t by new
                    {
                        t.ID,
                        t.Tarifa
                    }
                        into taxs
                        select new
                        {
                            ID = taxs.Key.ID,
                            Tarifa = taxs.Key.Tarifa,
                            Base = taxs.Sum(t => t.Base),
                            Value = taxs.Sum(t => t.Value)
                        })
                        {
                            Impuestos.Add(new Impuesto
                            {
                                ID = tax.ID,
                                Base = tax.Base,
                                Tarifa = tax.Tarifa.ToString().Replace(',', '.'),
                                Valor = Math.Round(tax.Base * tax.Tarifa / 100, 2),   ///Valor = tax.Value,
                                MonedaBase = this.Document.Moneda,
                                MonedaValor = this.Document.Moneda
                            });

                        }
                if (Impuestos.Count > 0)
                {
                    InvoiceType.TotalImpuestos.Add(new TotalImpuesto
                    {
                        ImpRetenido = stateTax,
                        Moneda = this.Document.Moneda,
                        Valor = Math.Round(Impuestos.Sum(s => s.Valor), 2),
                        Impuestos = Impuestos
                    });
                }

                /// ***
                Impuestos = new List<Impuesto>();
                foreach (var tax in
                    from t in taxes.Where(t => t.State.Equals(stateTax) && t.ID.Equals("02"))
                    group t by new
                    {
                        t.ID,
                        t.UnitMedida,
                        t.Base
                    }
                        into taxs
                        select new
                        {
                            ID = taxs.Key.ID,
                            UnitMedida = taxs.Key.UnitMedida,
                            Base = taxs.Key.Base,
                            Quantity = taxs.Sum(s => s.Quantity)
                        })
                        {
                            Impuestos.Add(new Impuesto
                            {
                                ID = tax.ID,
                                Base = tax.Quantity,
                                Quantity = tax.Quantity.ToString().Replace(',', '.'),
                                Valor = Math.Round(tax.Base * tax.Quantity, 2),
                                ValorUnit = tax.Base.ToString().Replace(',', '.'),
                                UnitMedida = tax.UnitMedida,
                                MonedaBase = this.Document.Moneda,
                                MonedaValor = this.Document.Moneda,
                                MonedaValorUnit = this.Document.Moneda
                            });


                        }
                if (Impuestos.Count > 0)
                {
                    /*double valor_ = Math.Round(Impuestos.Sum(s => s.Valor), 2);
                    double v = Math.Round(valor_, 2);*/

                    InvoiceType.TotalImpuestos.Add(new TotalImpuesto
                    {
                        ImpRetenido = stateTax,
                        Moneda = this.Document.Moneda,
                        Valor = Math.Round(Impuestos.Sum(s => s.Valor), 2),
                        Impuestos = Impuestos
                    });
                    
                }
            //}
            //else
            //{
                foreach (Tax tax in this.Document.Retentions)
                {
                    Impuestos = new List<Impuesto>();
                    Impuestos.Add(new Impuesto
                    {
                        ID = tax.ID,
                        Base = tax.Base,
                        Tarifa = tax.Tarifa.ToString().Replace(',', '.'),
                        Valor = tax.Value,
                        MonedaBase = this.Document.Moneda,
                        MonedaValor = this.Document.Moneda
                    });
                    InvoiceType.TotalImpuestos.Add(new TotalImpuesto
                    {
                        ImpRetenido = !stateTax,
                        Valor = Impuestos.Sum(s => s.Valor),
                        Impuestos = Impuestos,
                        Moneda = this.Document.Moneda
                    });
                }
            //}
        }

        private void LoadTotalImpuesto_(bool stateTax)
        {
            // añadir validacion si existen impuestos y retenciones 

            InvoiceType.TotalImpuestos = new List<TotalImpuesto>();

            List<Tax> taxes = new List<Tax>();
            foreach (var item in this.Document.Items)
            {
                taxes.AddRange(item.Taxes);
            }
            //var i_taxes = taxes.Where(t => t.State == stateTax);

            // dividir los grupos de impuesto 01:IVA; 02:IC... para agruparlos y generar los TIM & TII correspondientes.

            // Agrupo los de impuesto 01:IVA
            //from t in i_taxes.Where(i => i.ID.Equals("01"))

            List<Impuesto> Impuestos = new List<Impuesto>();
            foreach (var tax in
                from t in taxes.Where(t => t.State.Equals(stateTax) && t.ID.Equals("01"))
                group t by new
                {
                    t.ID,
                    t.Tarifa
                }
                    into taxs
                    select new
                    {
                        ID = taxs.Key.ID,
                        Tarifa = taxs.Key.Tarifa,
                        Base = taxs.Sum(t => t.Base),
                        Value = taxs.Sum(t => t.Value)
                    })
            {
                Impuestos.Add(new Impuesto
                {
                    ID = tax.ID,
                    Base = tax.Base,
                    Tarifa = tax.Tarifa.ToString(),
                    Valor = tax.Value,
                    MonedaBase = this.Document.Moneda,
                    MonedaValor = this.Document.Moneda
                });


                /*InvoiceType.TotalImpuestos.Add(new TotalImpuesto
                {
                    
                });*/
            }
            InvoiceType.TotalImpuestos.Add(new TotalImpuesto
            {
                ImpRetenido = stateTax,
                Moneda = this.Document.Moneda,
                Valor = Impuestos.Sum(s => s.Valor),
                Impuestos = Impuestos
            });
            /*foreach (var t in InvoiceType.TotalImpuestos)
            {
                t.ImpRetenido = stateTax;
                t.Moneda = this.Document.Moneda;
                t.Valor = t.Impuestos.Sum(s => s.Valor);
            }*/
            /// ***
            Impuestos = new List<Impuesto>();
            foreach (var tax in
                from t in taxes.Where(t => t.State.Equals(stateTax) && t.ID.Equals("02"))
                group t by new
                {
                    t.ID,
                    t.UnitMedida,
                    t.Base
                }
                    into taxs
                    select new
                    {
                        ID = taxs.Key.ID,
                        UnitMedida = taxs.Key.UnitMedida,
                        Base = taxs.Key.Base,
                        Quantity = taxs.Sum(s => s.Quantity)
                    })
            {
                Impuestos.Add(new Impuesto
                {
                    ID = tax.ID,
                    Base = tax.Quantity,
                    Quantity = tax.Quantity.ToString().Replace(',', '.'),
                    Valor = Math.Round(tax.Base * tax.Quantity, 2),
                    ValorUnit = tax.Base.ToString().Replace(',', '.'),
                    UnitMedida = tax.UnitMedida,
                    MonedaBase = this.Document.Moneda,
                    MonedaValor = this.Document.Moneda,
                    MonedaValorUnit = this.Document.Moneda
                });

                /*var i = new Impuesto();
                i.ID = tax.ID;
                ///i.Base = tax.Base;
                i.MonedaBase = this.Document.Moneda;
                i.Valor = tax.Value;
                i.MonedaValor = this.Document.Moneda;

                if (tax.Nominal)
                {
                    i.Base = tax.Quantity;
                    i.Quantity = tax.Quantity.ToString().Replace(',', '.');
                    i.UnitMedida = tax.UnitMedida;
                    i.ValorUnit = Math.Round(i.Valor / tax.Quantity, 2).ToString().Replace(',', '.'); ///i.Quantity; //tax.Quantity.ToString().Replace(',', '.');
                    i.MonedaValorUnit = this.Document.Moneda;
                }
                else
                {
                    i.Base = tax.Base;
                    i.Tarifa = tax.Tarifa.ToString();
                }
                impuestos.Add(i);*/
                /*
                InvoiceType.TotalImpuestos.Add(new TotalImpuesto
                {
                    Impuestos = new List<Impuesto>
                    {
                        new Impuesto 
                        {
                            ID = tax.ID,
                            Base = tax.Base,
                            Quantity = tax.Quantity.ToString().Replace(',', '.'),
                            Valor = Math.Round(tax.Base * tax.Quantity, 2),
                            MonedaBase = this.Document.Moneda,
                            MonedaValor = this.Document.Moneda,
                            MonedaValorUnit = this.Document.Moneda
                        }
                    }
                });
                */
            }
            InvoiceType.TotalImpuestos.Add(new TotalImpuesto
            {
                ImpRetenido = stateTax,
                Moneda = this.Document.Moneda,
                Valor = Impuestos.Sum(s => s.Valor),
                Impuestos = Impuestos
            });

            /*
            foreach (var t in InvoiceType.TotalImpuestos)
            {
                t.ImpRetenido = stateTax;
                t.Moneda = this.Document.Moneda;
                t.Valor = t.Impuestos.Sum(s => s.Valor);
            }*/

            var j = Impuestos;




            /*
            var taxGroup = from t in i_taxes
                           group t by new
                           {
                               t.ID,
                               t.Nominal,
                               t.Tarifa,
                               t.UnitMedida
                           } into taxs
                           select new
                           {
                               ID = taxs.Key.ID,
                               Nominal = taxs.Key.Nominal,
                               Tarifa = taxs.Key.Tarifa,
                               UnitMedida = taxs.Key.UnitMedida,
                               Base = taxs.Sum(t => t.Base),
                               Quantity = taxs.Sum(t => t.Quantity),
                               Value = taxs.Sum(t => t.Value)
                           };
            */

            /**
            foreach (var t in taxGroup.GroupBy(g => g.ID))
            {
                var impuestos = new List<Impuesto>();

                foreach (var tax in t.Where(t_ => t_.ID.Equals(t.Key)))
                {
                    var i = new Impuesto();
                    i.ID = tax.ID;
                    ///i.Base = tax.Base;
                    i.MonedaBase = this.Document.Moneda;
                    i.Valor = tax.Value;
                    i.MonedaValor = this.Document.Moneda;

                    if (tax.Nominal)
                    {
                        i.Base = tax.Quantity;
                        i.Quantity = tax.Quantity.ToString().Replace(',', '.');
                        i.UnitMedida = tax.UnitMedida;
                        i.ValorUnit = Math.Round(i.Valor / tax.Quantity, 2).ToString().Replace(',', '.'); ///i.Quantity; //tax.Quantity.ToString().Replace(',', '.');
                        i.MonedaValorUnit = this.Document.Moneda;
                    }
                    else
                    {
                        i.Base = tax.Base;
                        i.Tarifa = tax.Tarifa.ToString();
                    }
                    impuestos.Add(i);
                }

                InvoiceType.TotalImpuestos.Add(new TotalImpuesto
                {
                    ImpRetenido = stateTax,
                    Valor = impuestos.Sum(s => s.Valor),
                    Moneda = this.Document.Moneda,
                    Impuestos = impuestos
                });
            }
            */

            /**
            foreach (var ids in i_taxes.GroupBy(g => g.ID))
            {
                var impuestos = new List<Impuesto>();


                foreach (var tax in i_taxes.Where(t => t.ID.Equals(ids.Key)))
                {
                    var i = new Impuesto();
                    i.ID = tax.ID;
                    i.Base = tax.Base;
                    i.MonedaBase = this.Document.Moneda;
                    i.Valor = tax.Value;
                    i.MonedaValor = this.Document.Moneda;

                    if (tax.Nominal)
                    {
                        i.Quantity = tax.Quantity.ToString().Replace(',', '.');
                        i.UnitMedida = tax.UnitMedida;
                        i.ValorUnit = i.Quantity; //tax.Quantity.ToString().Replace(',', '.');
                        i.MonedaValorUnit = this.Document.Moneda;
                    }
                    else
                    {
                        i.Tarifa = tax.Tarifa.ToString();
                    }
                    impuestos.Add(i);

                }
                InvoiceType.TotalImpuestos.Add(new TotalImpuesto
                {
                    ImpRetenido = stateTax,
                    Valor = impuestos.Sum(s => s.Valor),
                    Moneda = this.Document.Moneda,
                    Impuestos = impuestos
                });
            }
            */
        }

        private void LoadItem()
        {
            InvoiceType.ItemFields = new List<ItemField>();

            foreach (var item in this.Document.Items)
            {
                var totalImpuestos = new List<TotalImpuestoItem>();
                ///var impuestos = new List<ImpuestoItem>();
                foreach (var tax in item.Taxes.OrderBy(o => o.ID))
                {
                    ///var totalImpuestos = new List<TotalImpuestoItem>();
                    var impuestos = new List<ImpuestoItem>();

                    var i = new ImpuestoItem();
                    i.ID = tax.ID;
                    i.Valor = tax.Value;
                    i.MonedaValor = this.Document.Moneda;
                    ///i.BaseImponible = tax.Base;
                    i.MonedaBaseImponible = this.Document.Moneda;

                    if (tax.Nominal) //Impuesto por valor: INC, BOLSAS
                    {
                        i.BaseImponible = tax.Quantity;
                        i.Quantity = tax.Quantity.ToString().Replace(',', '.');
                        i.UnitMedida = tax.UnitMedida;
                        i.ValorUnit = tax.Base.ToString().Replace(',', '.');
                        i.MonedaValorUnit = this.Document.Moneda;
                    }
                    else  // SINO: Impuesto por tarifa %
                    {
                        i.BaseImponible = tax.Base;
                        i.Tarifa = tax.Tarifa.ToString();
                    }
                    impuestos.Add(i);

                    /**
                    impuestos.Add(new ImpuestoItem
                    {
                        ID = tax.ID,
                        Valor = tax.Value,
                        MonedaValor = Header.Moneda,
                        BaseImponible = tax.Base,
                        MonedaBaseImponible = Header.Moneda,
                        Tarifa = tax.Tarifa
                    });
                    */

                    totalImpuestos.Add(new TotalImpuestoItem
                    {
                        Valor = tax.Value,
                        MonedaValor = this.Document.Moneda,
                        Retenido = tax.State,
                        Impuestos = impuestos
                    });
                }
                //var r = totalImpuestos.Where(ti => !ti.Retenido);
                //var j = r.Sum(s => s.Valor);
                InvoiceType.ItemFields.Add(new ItemField
                {
                    ID = item.Numero,
                    Code = item.Code,
                    Quantity = item.Quantity,
                    CodeMedida = item.UnitMedida,
                    SubTotal = item.SubTotal,
                    Price = item.UnitPrice,
                    Description = item.Description,
                    TotalItem = item.SubTotal,
                    //Total = r.Sum(s => s.Valor),
                    Total = Math.Round(item.SubTotal + totalImpuestos.Where(ti => !ti.Retenido).Sum(s => s.Valor), 3),
                    CantidadReal = item.Quantity,
                    CodMedidaCant = item.UnitMedida,

                    TotalImpuestos = totalImpuestos,

                    MonedaSubTotal = this.Document.Moneda,
                    MonedaPrice = this.Document.Moneda,
                    MonedaTotalItem = this.Document.Moneda,
                    MonedaTotal = this.Document.Moneda,

                    Standard = new IdentifyStandard
                    {
                        CodeProduct = item.TypeStandar.CodeItem,
                        CodeStandard = item.TypeStandar.CodeStandard
                    }
                });
            }
        }

        /*private string TributaryString(DataBaseDS.details_tributary_empresaDataTable tTributary)
        {

        }*/
    }
}