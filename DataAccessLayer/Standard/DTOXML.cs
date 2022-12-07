using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Standard
{
    [Serializable]
    [System.Xml.Serialization.XmlRoot("FACTURA")]
    public class InvoiceType
    {
        public InvoiceType() { }

        [System.Xml.Serialization.XmlElement("ENC")]
        public Heading Heading { set; get; }

        [System.Xml.Serialization.XmlElement("EMI")]
        public Emisor Emisor { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ")]
        public Adquiriente Adquiriente { set; get; }

        [System.Xml.Serialization.XmlElement("TOT")]
        public Total Total { set; get; }

        [System.Xml.Serialization.XmlElement("TIM")]
        public List<TotalImpuesto> TotalImpuestos { set; get; }

        [System.Xml.Serialization.XmlElement("DRF")]
        public Resolucion Resolucion { set; get; }

        [System.Xml.Serialization.XmlElement("MEP")]
        public MetodoPago MetodoPago { set; get; }


        [System.Xml.Serialization.XmlElement("ITE")]
        public List<ItemField> ItemFields { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("ENC")]
    public class Heading
    {
        [System.Xml.Serialization.XmlElement("ENC_1")]
        public string Document { set; get; } // Tipo de documento

        [System.Xml.Serialization.XmlElement("ENC_2")]
        public string NITEmisor { set; get; }

        [System.Xml.Serialization.XmlElement("ENC_3")]
        public string NITCliente { set; get; }

        [System.Xml.Serialization.XmlElement("ENC_4")]
        public string UBL { set; get; } // Universal Business Language - version

        [System.Xml.Serialization.XmlElement("ENC_5")]
        public string Version { set; get; } // Version del documento: DIAN 2.1

        [System.Xml.Serialization.XmlElement("ENC_6")]
        public string Numero { set; get; } // Número de documento (factura o factura cambiaria, nota crédito, nota débito).
        // Incluye prefijo + consecutivo de factura autorizados por la DIAN. 

        [System.Xml.Serialization.XmlElement("ENC_7")]
        public string Fecha { set; get; } // Fecha de emisión de la factura, formato AAAA-MM-DD

        [System.Xml.Serialization.XmlElement("ENC_8")]
        public string Hora { set; get; } // Hora de emisión de la factura, Formato: HH:MM:SSdhh:mm

        [System.Xml.Serialization.XmlElement("ENC_9")]
        public string Tipo { set; get; } // Tipo de factura 01 FACTURA DE VENTA NACIONAL

        [System.Xml.Serialization.XmlElement("ENC_10")]
        public string CodMoneda { set; get; } // Divisa consolidada aplicable a toda la factura

        [System.Xml.Serialization.XmlElement("ENC_15")]
        public string NoItems { set; get; } // Número total de lineas (items - productos) en el documento

        [System.Xml.Serialization.XmlElement("ENC_16")]
        public string DateEnd { set; get; }  // Fecha de vencimiento

        [System.Xml.Serialization.XmlElement("ENC_20")]
        public string CodAmbiente { set; get; } // 1 = producción ; 2 = pruebas, demo

        [System.Xml.Serialization.XmlElement("ENC_21")]
        public string TipoOperation { set; get; } // 10 = estándar.
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("EMI")]
    public class Emisor
    {
        [System.Xml.Serialization.XmlElement("EMI_1")]
        public string Tipo { set; get; } // 1 _ Jurídica; 2 = Natural

        [System.Xml.Serialization.XmlElement("EMI_2")]
        public string NIT { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_3")]
        public int TipoIdentify { set; get; } // Cedula, NIT, en colombia es NIT = 31

        [System.Xml.Serialization.XmlElement("EMI_4")]
        public int Regimen { set; get; } // Regimen fiscal:  48 = Resp de IVA;  49 = No Resp de IVA

        [System.Xml.Serialization.XmlElement("EMI_6")]
        public string RazonSocial { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_7")]
        public string NameComercial { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_10")]
        public string Direccion { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_11")]
        public string CodDepartamento { set; get; } // Codigo del departamento de ubicacion del emisor.

        [System.Xml.Serialization.XmlElement("EMI_13")]
        public string Ciudad { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_14")]
        public string CodPostal { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_15")]
        public string CodPais { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_19")]
        public string Departamento { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_21")]
        public string Pais { set; get; }

        /// <summary>
        /// Digito de verificación del NIT.
        /// </summary>
        [System.Xml.Serialization.XmlElement("EMI_22")]
        public int DV { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_23")]
        public string CodMunicipio { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_24")]
        public string NameRUT { set; get; }

        [System.Xml.Serialization.XmlElement("EMI_25")]
        public string CIIU { set; get; }

        [System.Xml.Serialization.XmlElement("TAC")]
        public Tributary Tributary { set; get; }

        [System.Xml.Serialization.XmlElement("DFE")]
        public AddressEmisor AddressEmisor { set; get; }

        [System.Xml.Serialization.XmlElement("ICC")]
        public CommerceInformation CommerceInformation { set; get; }

        [System.Xml.Serialization.XmlElement("CDE")]
        public ContactoEmisor ContactoEmisor { set; get; }

        [System.Xml.Serialization.XmlElement("GTE")]
        public GrupoTributo GrupoTributo { set; get; }
    }

    /// <summary>
    /// Representa una clase para asignar la responsabilidad tributaria. "Contribuyente"
    /// </summary>
    [Serializable]
    [System.Xml.Serialization.XmlRoot("TAC")]
    public class Tributary
    {
        /// <summary>
        /// Código de la responsabilidad tributaria del emisor.
        /// </summary>
        [System.Xml.Serialization.XmlElement("TAC_1")]
        public string Code { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("DFE")]
    public class AddressEmisor
    {
        [System.Xml.Serialization.XmlElement("DFE_1")]
        public string CodMunicipio { set; get; }

        [System.Xml.Serialization.XmlElement("DFE_2")]
        public string CodDepartamento { set; get; }

        [System.Xml.Serialization.XmlElement("DFE_3")]
        public string CodPais { set; get; }

        [System.Xml.Serialization.XmlElement("DFE_4")]
        public string CodigoPostal { set; get; }

        [System.Xml.Serialization.XmlElement("DFE_5")]
        public string Pais { set; get; }

        [System.Xml.Serialization.XmlElement("DFE_6")]
        public string Departamento { set; get; }

        [System.Xml.Serialization.XmlElement("DFE_7")]
        public string Ciudad { set; get; }

        [System.Xml.Serialization.XmlElement("DFE_8")]
        public string Direccion { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("ICC")]
    public class CommerceInformation
    {
        [System.Xml.Serialization.XmlElement("ICC_1")]
        public string NumeroMatricula { set; get; } //Número de matrícula mercantil (Identificador de sucursal: Punto de facturación)

        [System.Xml.Serialization.XmlElement("ICC_9")]
        public string PrefijoFactura { set; get; } //Prefijo de la facturación usada para el punto de venta. 
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("CDE")]
    public class ContactoEmisor
    {
        [System.Xml.Serialization.XmlElement("CDE_1")]
        public int Tipo { set; get; } //1: Persona, 2: Despacho, 3: Contabilidad, 4: Ventas

        [System.Xml.Serialization.XmlElement("CDE_2")]
        public string Nombre { set; get; }

        [System.Xml.Serialization.XmlElement("CDE_3")]
        public string Telefono { set; get; }

        [System.Xml.Serialization.XmlElement("CDE_4")]
        public string Email { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("GTE")]
    public class GrupoTributo
    {
        [System.Xml.Serialization.XmlElement("GTE_1")]
        public string Codigo { set; get; }

        [System.Xml.Serialization.XmlElement("GTE_2")]
        public string Nombre { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("ADQ")]
    public class Adquiriente
    {
        [System.Xml.Serialization.XmlElement("ADQ_1")]
        public string Tipo { set; get; } // 1: Juridica, 2: Natural

        [System.Xml.Serialization.XmlElement("ADQ_2")]
        public string NIT { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_3")]
        public int Identify { set; get; }   // Cedula, NIT, en colombia es NIT = 31

        [System.Xml.Serialization.XmlElement("ADQ_4")]
        public int Regimen { set; get; } // Regimen fiscal:  48 = Resp de IVA;  49 = No Resp de IVA

        [System.Xml.Serialization.XmlElement("ADQ_6")]
        public string RazonSocial { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_7")]
        public string NameComercial { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_8")]
        public string Name { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_9")]
        public string LastName { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_10")]
        public string Direccion { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_11")]
        public string CodDepartamento { set; get; } // Codigo del departamento de ubicacion del adquiriente.

        [System.Xml.Serialization.XmlElement("ADQ_13")]
        public string Ciudad { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_14")]
        public string CodPostal { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_15")]
        public string CodPais { set; get; } // Código para Colombia = CO

        [System.Xml.Serialization.XmlElement("ADQ_19")]
        public string Departamento { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_21")]
        public string Pais { set; get; }

        /// <summary>
        /// Digito de verificación del NIT.
        /// </summary>
        [System.Xml.Serialization.XmlElement("ADQ_22")]
        public int DV { set; get; }

        [System.Xml.Serialization.XmlElement("ADQ_23")]
        public string CodMunicipio { set; get; }

        //[System.Xml.Serialization.XmlElement("ADQ_24")]
        //public int TipoUser { set; get; } // 1

        [System.Xml.Serialization.XmlElement("TCR")]
        public TributaryADQ TributaryADQ { set; get; }

        [System.Xml.Serialization.XmlElement("ILA")]
        public InformacionLegal InformacionLegal { set; get; }

        [System.Xml.Serialization.XmlElement("DFA")]
        public AddressAdquiriente AddressAdquiriente { set; get; }

        [System.Xml.Serialization.XmlElement("CDA")]
        public ContactoAdquiriente ContactoAdquiriente { set; get; }

        [System.Xml.Serialization.XmlElement("GTA")]
        public GrupoTributoAdquiriente GrupoTributoAdquiriente { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("TCR")]
    public class TributaryADQ
    {
        [System.Xml.Serialization.XmlElement("TCR_1")]
        public string Codigo { set; get; } // Código responsabilidades del adquiriente.
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("ILA")]
    public class InformacionLegal
    {
        [System.Xml.Serialization.XmlElement("ILA_1")]
        public string NameRUT { set; get; } // Nombre registrado en el RUT

        [System.Xml.Serialization.XmlElement("ILA_2")]
        public string NIT { set; get; }

        [System.Xml.Serialization.XmlElement("ILA_3")]
        public int TypeIdentify { set; get; } // Tipo de documento de identificacion, 31: NIT.

        [System.Xml.Serialization.XmlElement("ILA_4")]
        public int DV { set; get; } // Digito de Verificación del NIT.
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("DFA")]
    public class AddressAdquiriente
    {
        [System.Xml.Serialization.XmlElement("DFA_1")]
        public string CodigoPais { set; get; }  // Colombia = CO

        [System.Xml.Serialization.XmlElement("DFA_2")]
        public string CodDepartamento { set; get; }

        [System.Xml.Serialization.XmlElement("DFA_3")]
        public string CodigoPostal { set; get; }

        [System.Xml.Serialization.XmlElement("DFA_4")]
        public string CodMunicipio { set; get; }

        [System.Xml.Serialization.XmlElement("DFA_5")]
        public string Pais { set; get; }

        [System.Xml.Serialization.XmlElement("DFA_6")]
        public string Departamento { set; get; }

        [System.Xml.Serialization.XmlElement("DFA_7")]
        public string Ciudad { set; get; }

        [System.Xml.Serialization.XmlElement("DFA_8")]
        public string Direccion { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("CDA")]
    public class ContactoAdquiriente
    {
        [System.Xml.Serialization.XmlElement("CDA_1")]
        public int Tipo { set; get; } //1: Persona, 2: Despacho, 3: Contabilidad, 4: Ventas

        [System.Xml.Serialization.XmlElement("CDA_2")]
        public string Nombre { set; get; }

        [System.Xml.Serialization.XmlElement("CDA_3")]
        public string Telefono { set; get; }

        [System.Xml.Serialization.XmlElement("CDA_4")]
        public string Email { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("GTA")]
    public class GrupoTributoAdquiriente
    {
        [System.Xml.Serialization.XmlElement("GTA_1")]
        public string Codigo { set; get; }

        [System.Xml.Serialization.XmlElement("GTA_2")]
        public string Nombre { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("TOT")]
    public class Total
    {
        [System.Xml.Serialization.XmlElement("TOT_1")]
        public double Base { set; get; } // Valor bruto antes de tributos: Total valor bruto, suma de los valores brutos de las líneas de la factura.

        [System.Xml.Serialization.XmlElement("TOT_2")]
        public string MonedaBase { set; get; } // Moneda total Importe bruto antes de impuestos. 

        [System.Xml.Serialization.XmlElement("TOT_3")]
        public double BaseImponible { set; get; }

        [System.Xml.Serialization.XmlElement("TOT_4")]
        public string MonedaBaseImponible { set; get; }

        [System.Xml.Serialization.XmlElement("TOT_5")]
        public double ValorPago { set; get; } // Valor a pagar de la factura (menos anticipos)

        [System.Xml.Serialization.XmlElement("TOT_6")]
        public string MonedaValor { set; get; }

        [System.Xml.Serialization.XmlElement("TOT_7")]
        public double ValorTotal { set; get; } // Valor mas tributos

        [System.Xml.Serialization.XmlElement("TOT_8")]
        public string MonedaTotal { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("TIM")]
    public class TotalImpuesto
    {
        [System.Xml.Serialization.XmlElement("TIM_1")]
        public bool ImpRetenido { set; get; } // true: retención, false: impuesto

        [System.Xml.Serialization.XmlElement("TIM_2")]
        public double Valor { set; get; }

        [System.Xml.Serialization.XmlElement("TIM_3")]
        public string Moneda { set; get; }

        [System.Xml.Serialization.XmlElement("IMP")]
        public List<Impuesto> Impuestos { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("IMP")]
    public class Impuesto
    {
        [System.Xml.Serialization.XmlElement("IMP_1")]
        public string ID { set; get; } // Identificador del impuesto: 01 = IVA

        [System.Xml.Serialization.XmlElement("IMP_2")]
        public double Base { set; get; }

        [System.Xml.Serialization.XmlElement("IMP_3")]
        public string MonedaBase { set; get; }

        [System.Xml.Serialization.XmlElement("IMP_4")]
        public double Valor { set; get; }

        [System.Xml.Serialization.XmlElement("IMP_5")]
        public string MonedaValor { set; get; }

        [System.Xml.Serialization.XmlElement("IMP_6")]
        public string Tarifa { set; get; }

        [System.Xml.Serialization.XmlElement("IMP_7")]
        public string Quantity { set; get; }

        [System.Xml.Serialization.XmlElement("IMP_8")]
        public string UnitMedida { set; get; } // codigo de la unidad de medida.

        [System.Xml.Serialization.XmlElement("IMP_9")]
        public string ValorUnit { set; get; }  // Valor unitario del tributo

        [System.Xml.Serialization.XmlElement("IMP_10")]
        public string MonedaValorUnit { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("DRF")]
    public class Resolucion
    {
        [System.Xml.Serialization.XmlElement("DRF_1")]
        public string Number { set; get; }

        [System.Xml.Serialization.XmlElement("DRF_2")]
        public string DateBegin { set; get; }

        [System.Xml.Serialization.XmlElement("DRF_3")]
        public string DateEnd { set; get; }

        [System.Xml.Serialization.XmlElement("DRF_4")]
        public string Prefijo { set; get; }

        [System.Xml.Serialization.XmlElement("DRF_5")]
        public int NumberBegin { set; get; }

        [System.Xml.Serialization.XmlElement("DRF_6")]
        public int NumberEnd { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("MEP")]
    public class MetodoPago
    {
        [System.Xml.Serialization.XmlElement("MEP_1")]
        public string CodMedio { set; get; } // Inidica el codigo del medio como se paga en dinero.

        [System.Xml.Serialization.XmlElement("MEP_2")]
        public int CodMetodo { set; get; } // Indica si es de contado o crédito

        [System.Xml.Serialization.XmlElement("MEP_3")]
        public string Date { set; get; }
    }

    /// <summary>
    /// Represent a clas from items(products) for invoice
    /// </summary>
    [Serializable]
    [System.Xml.Serialization.XmlRoot("ITE")]
    public class ItemField
    {
        /// <summary>
        /// The consecutive of the line, consecutive of item in the invoice.
        /// </summary>
        [System.Xml.Serialization.XmlElement("ITE_1")]
        public int ID { set; get; }

        [System.Xml.Serialization.XmlElement("ITE_3")]
        public double Quantity { set; get; } // Cantidad de productos.

        [System.Xml.Serialization.XmlElement("ITE_4")]
        public string CodeMedida { set; get; } // Codigo de la unidad de producto/servicio

        [System.Xml.Serialization.XmlElement("ITE_5")]
        public double SubTotal { set; get; } // Valor total de la línea. Cantidad x Precio Unidad

        [System.Xml.Serialization.XmlElement("ITE_6")]
        public string MonedaSubTotal { set; get; } // Moneda del valor total de la línea.

        [System.Xml.Serialization.XmlElement("ITE_7")]
        public double Price { set; get; } // Costo unitario del producto

        [System.Xml.Serialization.XmlElement("ITE_8")]
        public string MonedaPrice { set; get; } // Moneda del precio(costo) unitario

        [System.Xml.Serialization.XmlElement("ITE_11")]
        public string Description { set; get; } // Descripción del producto o servicio

        [System.Xml.Serialization.XmlElement("ITE_18")]
        public string Code { set; get; } // Código (del vendedor) correspondiente al artículo


        [System.Xml.Serialization.XmlElement("ITE_19")]
        public double TotalItem { set; get; }  // Total del ítem (incluyendo Descuentos y cargos)

        [System.Xml.Serialization.XmlElement("ITE_20")]
        public string MonedaTotalItem { set; get; } // Moneda del Total del ítem (incluyendo Descuentos y cargos)

        [System.Xml.Serialization.XmlElement("ITE_21")]
        public double Total { set; get; } // Valor a pagar del ítem

        [System.Xml.Serialization.XmlElement("ITE_22")]
        public string MonedaTotal { set; get; } // Moneda del Valor a pagar del ítem

        [System.Xml.Serialization.XmlElement("ITE_27")]
        public double CantidadReal { set; get; } // La cantidad real sobre la cual el precio aplica. 

        [System.Xml.Serialization.XmlElement("ITE_28")]
        public string CodMedidaCant { set; get; } // Codigo de la unidad de medida de la cantidad

        [System.Xml.Serialization.XmlElement("IAE")]
        public IdentifyStandard Standard { set; get; }

        [System.Xml.Serialization.XmlElement("TII")]
        public List<TotalImpuestoItem> TotalImpuestos { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("IAE")]
    public class IdentifyStandard
    {
        [System.Xml.Serialization.XmlElement("IAE_1")]
        public string CodeProduct { set; get; } // Código del producto acuerdo con el estándar descrito en el campo  IAE_2

        [System.Xml.Serialization.XmlElement("IAE_2")]
        public string CodeStandard { set; get; } // Código del estándar. 
        // Se debe enviar el valor de la columna "schemeID" de la tabla 31.
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("TII")]
    public class TotalImpuestoItem
    {
        [System.Xml.Serialization.XmlElement("TII_1")]
        public double Valor { set; get; }

        [System.Xml.Serialization.XmlElement("TII_2")]
        public string MonedaValor { set; get; }

        [System.Xml.Serialization.XmlElement("TII_3")]
        public bool Retenido { set; get; } // Impuesto retenido o retención = true; Impuesto = false

        [System.Xml.Serialization.XmlElement("IIM")]
        public List<ImpuestoItem> Impuestos { set; get; }
    }

    [Serializable]
    [System.Xml.Serialization.XmlRoot("IIM")]
    public class ImpuestoItem
    {
        [System.Xml.Serialization.XmlElement("IIM_1")]
        public string ID { set; get; } // Identificador del tributo

        [System.Xml.Serialization.XmlElement("IIM_2")]
        public double Valor { set; get; }  // Valor del tributo.  producto del porcentaje aplicado sobre la base imponible

        [System.Xml.Serialization.XmlElement("IIM_3")]
        public string MonedaValor { set; get; } // Moneda del valor del tributo

        [System.Xml.Serialization.XmlElement("IIM_4")]
        public double BaseImponible { set; get; } // Base Imponible sobre la que se calcula el valor del tributo

        [System.Xml.Serialization.XmlElement("IIM_5")]
        public string MonedaBaseImponible { set; get; } // moneda de la base imponible

        [System.Xml.Serialization.XmlElement("IIM_6")]
        public string Tarifa { set; get; } // Tarifa del tributo(Impuesto)

        [System.Xml.Serialization.XmlElement("IIM_7")]
        public string Quantity { set; get; } // Cant, Unidad de medida del impuesto nominal

        [System.Xml.Serialization.XmlElement("IIM_8")]
        public string UnitMedida { set; get; } // codigo de la unidad de medida.

        [System.Xml.Serialization.XmlElement("IIM_9")]
        public string ValorUnit { set; get; }  // Valor unitario del tributo

        [System.Xml.Serialization.XmlElement("IIM_10")]
        public string MonedaValorUnit { set; get; }
    }
}
