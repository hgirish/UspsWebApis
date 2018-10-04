using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UspsWebApis.Models.RateResponse
{

    public class IntlRateV2Response
    {
        
        public Package Package { get; set; }
    }
}
