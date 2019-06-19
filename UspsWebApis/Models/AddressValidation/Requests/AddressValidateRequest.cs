using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UspsWebApis.Models.AddressValidation.Requests
{
    public class AddressValidateRequest
    {
        [XmlAttribute("USERID")]
        public string UserId { get; set; }
        [XmlAttribute("PASSWORD")]
        public string Password { get; set; }
        [XmlAttribute("APPID")]
        public string AppId { get; set; }
        public string Revision { get; set; } = "2";
        public Address Address { get; set; }

    }
    
}
