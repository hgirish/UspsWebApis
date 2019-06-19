using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using UspsWebApis.Models;
using UspsWebApis.Models.AddressValidation.Requests;
using UspsWebApis.Models.AddressValidation.Responses;

namespace UspsWebApis.Controllers
{
    [Route("api/[controller]")]
    public class AddressValidationController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public AddressValidationController(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync(Address model)
        {
            var webRootPath = _hostingEnvironment.ContentRootPath;
           
            Address address = new Address
            {
                Address1 = model.Address1 ?? "",
                Address2 = model.Address2 ?? "",
                State = model.State ?? "",
                City = model.City ?? "",
                Zip5 = model.Zip5 ?? "",
                Zip4 = model.Zip4 ?? "",
                FirmName = model.FirmName ?? "",
                Urbanization = model.Urbanization ?? ""
            };

    
            string userId = _configuration["USPS:UserId"];
            AddressValidateRequest request = new AddressValidateRequest
            {
                Address = address,
                UserId = userId,
            };
           
            XmlSerializer xsSubmit = new XmlSerializer(typeof(AddressValidateRequest));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, request);
                    xml = sww.ToString();
                }
            }
            var requestXmlFile = Path.Combine(webRootPath, "request.xml");
            System.IO.File.WriteAllText(requestXmlFile, xml);
            //string uspsUrl = "http://production.shippingapis.com/ShippingAPI.dll";
            string uspsUrl = "https://secure.shippingapis.com/ShippingAPI.dll";
            var formData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("API", "Verify"),
                new KeyValuePair<string, string>("XML", xml)
            });
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(uspsUrl, formData);
            var content = await response.Content.ReadAsStringAsync();

            var responseXmlFile = Path.Combine(webRootPath, "response.xml");
            System.IO.File.WriteAllText(responseXmlFile, content);

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(AddressValidateResponse));
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                AddressValidateResponse responseJson = (AddressValidateResponse)deserializer.Deserialize(ms);
                return Ok(responseJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //XmlSerializer serializer = new XmlSerializer(typeof(Error));
                //var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                //Error error = (Error)serializer.Deserialize(ms);
                return NotFound(ex.Message);
            }
        }
    }
}
