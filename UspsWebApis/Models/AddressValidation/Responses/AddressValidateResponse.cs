using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UspsWebApis.Models.AddressValidation.Responses
{
    [Serializable]
    public class AddressValidateResponse
    {
        public ResponseAddress Address { get; set; }
    }
}
