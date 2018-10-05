using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UspsWebApis.Models.Domestic.Requests
{
    [Serializable]
    public class Package
    {
        [XmlAttribute("ID")]
        public string PackageId { get; set; }
        public string Service { get; set; }
        public string FirstClassMailType { get; set; }
        public string ZipOrigination { get; set; }
        public string ZipDestination { get; set; }
        public int Pounds { get; set; }
        public int Ounces { get; set; }
        public string Container { get; set; }
        public string Size { get; set; }
        public string Machinable { get; set; }
        
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Girth { get; set; }
        public string Value { get; set; }
        public SpecialServices SpecialServices { get; set; }
        public string DropOffTime { get; set; }
        public string ShipDate { get; set; }
        public string RatePriceType { get; set; }
        public string RatePaymentType { get; set; }
    }

}
