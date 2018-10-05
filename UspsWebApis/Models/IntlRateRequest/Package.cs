using System;
using System.Xml.Serialization;

namespace UspsWebApis.Models.IntlRateRequest
{

    public class IntlRequestPackage
    {
        public decimal? Pounds { get; set; } = 0;
        public decimal? Ounces { get; set; } = 0;
        public string Machinable { get; set; }
        public string MailType { get; set; } = "Package";
        public GXG GXG { get; set; }
        public string ValueOfContents { get; set; }
        public string Country { get; set; }
        public string Container { get; set; }
        public string Size { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Girth { get; set; }
        public string OriginZip { get; set; }
        public string CommercialFlag { get; set; }
        public DateTime? AcceptanceDateTime { get; set; }
        public string DestinationPostalCode { get; set; }
        [XmlAttribute("ID")]
        public string PackageId { get; set; }

        public bool ShouldSerializePounds()
        {
            return Pounds.HasValue;
        }
        public bool ShouldSerializeOunces()
        {
            return Ounces.HasValue;
        }
        public bool ShouldSerializeAcceptanceDateTime()
        {
            return AcceptanceDateTime.HasValue;
        }
    }

}
