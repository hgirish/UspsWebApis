using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UspsWebApis.Models.RateResponse;

namespace UspsWebApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public ValuesController(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var path = hostingEnvironment.WebRootPath;
            var xmlFile = Path.Combine(path, "responsetrim.xml");
            var content = System.IO.File.ReadAllText(xmlFile);
            XmlSerializer deserializer = new XmlSerializer(typeof(IntlRateV2Response));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
            IntlRateV2Response responseJson =(IntlRateV2Response) deserializer.Deserialize(ms);
          //  JsonConvert.DeserializeObject<IntlRateV2Response>(content);
            return Ok(responseJson);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //XmlSerializer deserializer = new XmlSerializer(typeof(IntlRateV2Response));
            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(content));
            //var responseJson = deserializer.Deserialize(ms);
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
