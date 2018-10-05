using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace UspsWebApis.Models.RateResponse
{
    [Serializable]
    public class ExtraServices
    {[XmlArray][XmlArrayItem(typeof(ExtraService))]
        public List<ExtraService> ExtraService { get; set; }
    }
}
