using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GardenWebApp.Controllers
{
    public class Plant
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
    public class ValuesController : ApiController
    {
        private static Plant[] garden = new Plant[]
        {
            new Plant()
            {
                Id = "0",
                Name = "Spinach",
                Category = "Greens"
            },

            new Plant()
            {
                Id = "1",
                Name = "Bell Pepper",
                Category = "Fruit"
            },

            new Plant()
            {
                Id = "2",
                Name = "Carrots",
                Category = "Root"
            }
        };

        // GET api/values
        //public IEnumerable<string> Get()
        //{


        //  return new string[] { "value1", "value2" };
        //}

        // GET api/values
        public IEnumerable<Plant> Get()
        {
            return garden;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
