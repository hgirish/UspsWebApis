using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace UspsWebApis.Models.RateResponse
{
    [Serializable]
    public class ResponsePackage
    {
        [JsonIgnore]
        public string Prohibitions { get; set; }
        [JsonIgnore]
        public string Restrictions { get; set; }
        [JsonIgnore]
        public string Observations { get; set; }
        [JsonIgnore]
        public string CustomsForms { get; set; }
        [JsonIgnore]
        public string ExpressMail { get; set; }
        public string AreasServed { get; set; }
        [JsonIgnore]
        public string AdditionalRestrictions { get; set; }
        //[XmlArray]
        //[XmlArrayItem(typeof(Service))]
        public Service Service { get; set; }
        [XmlAttribute("ID")]
        public string PackageId { get; set; }
    }
}
