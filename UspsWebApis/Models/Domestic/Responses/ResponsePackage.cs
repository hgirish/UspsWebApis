using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UspsWebApis.Models.Domestic.Responses
{
    [Serializable]
    public class ResponsePackage
    {
        public string ZipOrigination { get; set; }
        public string ZipDestination { get; set; }
        public string Pounds { get; set; }
        public string Ounces { get; set; }
        public string Size { get; set; }
        public string Machinable { get; set; }
        public string Zone { get; set; }
        [XmlElement("Postage")]
        public List<Postage> Postage { get; set; }
        [XmlAttribute("ID")]
        public string PackageId { get; set; }
        public Error Error { get; set; }
    }
}
