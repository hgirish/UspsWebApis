using System.Collections.Generic;

namespace UspsWebApis.Models.RateResponse
{
    public class Package
    {
        public string Prohibitions { get; set; }
        public string Restrictions { get; set; }
        public string Observations { get; set; }
        public string CustomsForms { get; set; }
        public string ExpressMail { get; set; }
        public string AreasServed { get; set; }
        public string AdditionalRestrictions { get; set; }
        public IList<Service> Service { get; set; }
        public string _ID { get; set; }
    }
}
