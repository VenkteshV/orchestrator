using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Http;

using orchestrator.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

using Newtonsoft.Json;
using System.Diagnostics;


namespace orchestrator.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        public static  async Task<JObject>  GetData(Service service)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(service.Endpoint),
                    Method = HttpMethod.Get,
                };
                var response = await client.SendAsync(request);
                if (((int)response.StatusCode) == 200)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    service.Response = JObject.Parse(stringResponse);
                    service.Success = true;
                }
                else
                {
                    service.Success = false;
                }
            }
            return service.Response;
        }
        public static Services ReadFile(string configurationFile)
        {
            try
            {
                var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string document = System.IO.File.ReadAllText(@"" + projectFolder + "/src/orchestrator/YAML/" + configurationFile + ".yml");
                StringReader input = new StringReader(document);
                DeserializerBuilder deserializeBuilder = new DeserializerBuilder();
                deserializeBuilder.WithNamingConvention(new CamelCaseNamingConvention());
                Deserializer deserializer = deserializeBuilder.Build();
                return deserializer.Deserialize<Services>(input);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        // GET api/services
        [HttpGet]
        public JArray Get()
        {
            JArray Response = new JArray();
            Services services = ReadFile("service");
            foreach (Service service in services.ListOfServices)
            {
               Response.Add(GetData(service).Result);

            }
            return Response;
            }

        // GET api/services/5
        [HttpGet("{Key}")]
        public string Get(String Key)
        {
            return "value";
        }




    }
}
