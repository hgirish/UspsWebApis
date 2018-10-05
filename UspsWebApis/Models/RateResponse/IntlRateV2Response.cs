using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UspsWebApis.Models.RateResponse
{
    [Serializable]
    public class IntlRateV2Response
    {
        
        public ResponsePackage Package { get; set; }
        public Error Error { get; set; }
    }
}
