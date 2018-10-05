using System;

namespace UspsWebApis.Models.Domestic.Responses
{
    [Serializable]
    public class RateV4Response
    {
        public ResponsePackage Package { get; set; }
        public Error Error { get; set; }
    }
}
