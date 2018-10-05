using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UspsWebApis.Models;
using UspsWebApis.Models.Domestic.Requests;
using UspsWebApis.Models.Domestic.Responses;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UspsWebApis.Controllers
{
    [Route("api/[controller]")]
    public class RateController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public RateController(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        // GET: api/<controller>
        [HttpGet]
        public async System.Threading.Tasks.Task<IActionResult> GetAsync()
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            Package package = new Package() { PackageId = "0", Service = "ALL", FirstClassMailType = "PACKAGE SERVICE",ZipOrigination="90001",
            ZipDestination = "10001",
            Pounds = 0,
            Ounces = 6,
            Container="VARIABLE",
            Size = "REGULAR",
            Machinable = "FALSE"
            };
            string userId = _configuration["USPS:UserId"];

            RateV4Request request = new RateV4Request
            {
                Package =package,
                UserId = userId
            };
            XmlSerializer xsSubmit = new XmlSerializer(typeof(RateV4Request));
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
            string uspsUrl = "http://production.shippingapis.com/ShippingAPI.dll";
            var formData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("API", "RateV4"),
                new KeyValuePair<string, string>("XML", xml)
            });
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(uspsUrl, formData);
            var content = await response.Content.ReadAsStringAsync();
          
            var responseXmlFile = Path.Combine(webRootPath, "response.xml");
            System.IO.File.WriteAllText(responseXmlFile, content);

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(RateV4Response));
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                RateV4Response responseJson = (RateV4Response)deserializer.Deserialize(ms);
                return Ok(responseJson);
            }
            catch (Exception ex)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Error));
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
                Error error = (Error)serializer.Deserialize(ms);
                return NotFound(error);
            }

           
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
