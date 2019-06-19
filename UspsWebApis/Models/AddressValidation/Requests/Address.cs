using System.ComponentModel.DataAnnotations;

namespace UspsWebApis.Models.AddressValidation.Requests
{
    public class Address
    {
        public string FirmName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [MaxLength(15)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(28)]
        public string Urbanization { get; set; } // For Puerto Rico adddress only
        [MaxLength(5)]
        [RegularExpression("^[0-9]{5}")]
        public string Zip5 { get; set; }
        [MaxLength(4)][RegularExpression("^[0-9]{4}")]
        public string Zip4 { get; set; }


    }
}
