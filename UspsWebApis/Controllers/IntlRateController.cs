using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UspsWebApis.Models;
using UspsWebApis.Models.RateResponse;

namespace UspsWebApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntlRateController : ControllerBase
    {
        public async Task<IActionResult> GetAsync()
        {
            Models.Package package = new Models.Package
            {
               // AcceptanceDateTime = DateTime.UtcNow.AddDays(1),
                Country = "Canada",
                OriginZip = "90001",
                Ounces = 15.0m,
                PackageId = "1",
                ValueOfContents = "10.00",
                Container = "RECTANGULAR",
                Size = "REGULAR",
                Width = "15",
                Length = "15",
                Height = "16",
                Girth = "15",

            };
            IntlRateV2Request intlRateV2Request = new IntlRateV2Request
            {
                Package = package

            };
            XmlSerializer xsSubmit = new XmlSerializer(typeof(IntlRateV2Request));
            
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, intlRateV2Request);
                    xml = sww.ToString();
                }
            }
            string uspsUrl = "http://production.shippingapis.com/ShippingAPI.dll";
            var formData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("API", "IntlRateV2"),
                new KeyValuePair<string, string>("XML", xml)
            });
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(uspsUrl, formData);
            var content = await  response.Content.ReadAsStringAsync();
            System.IO.File.WriteAllText("response.xml", content);
            //XmlSerializer deserializer = new XmlSerializer(typeof(IntlRateV2Response));
            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
            //var responseJson = deserializer.Deserialize(ms);
            XmlSerializer deserializer = new XmlSerializer(typeof(IntlRateV2Response));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
            IntlRateV2Response responseJson = (IntlRateV2Response)deserializer.Deserialize(ms);
            return Ok(responseJson);
        }
    }
}
