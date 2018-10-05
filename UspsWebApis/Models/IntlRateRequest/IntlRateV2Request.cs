using System.Xml.Serialization;

namespace UspsWebApis.Models.IntlRateRequest
{
    public class IntlRateV2Request
    {
        public string Revision { get; set; } = "2";
        public IntlRequestPackage Package { get; set; }
        [XmlAttribute("USERID")]
        public string UserId { get; set; } = "prodsolclient";
    }
}
