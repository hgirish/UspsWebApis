using System;
using System.Xml.Serialization;

namespace UspsWebApis.Models.Domestic.Responses
{
    [Serializable]
    public class Postage
    {
        public string MailService { get; set; }
        public decimal Rate { get; set; }
        [XmlAttribute("CLASSID")]
        public string ClassId { get; set; }
    }
}
