using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace UspsWebApis.Models.Domestic.Requests
{
    [Serializable]
    public class RateV4Request
    {
        public string Revision { get; set; } = "2";
        public Package Package { get; set; }
        [XmlAttribute("USERID")]
        public string UserId { get; set; }
    }

}
