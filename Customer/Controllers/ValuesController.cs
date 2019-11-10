using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Customer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var log = LogTask("Information", "Get Customer");
                return new string[] { "Customer - value1", "value2" };
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", "Customer error: " + ex.Message);
                return null;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User value)
        {
            try
            {
                var log = LogTask("Information", "New User" + value.name +" registered");
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            try
            {
                var log = LogTask("Information", "Updated User" + value.name);
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var log = LogTask("Information", "User deleted for: " + id);
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", ex.Message);
            }
        }

        private async Task LogTask(string typ, string value)
        {
            var data = new
            {
                apiName = "Customer",
                exception = value,
                type = typ,
                time = DateTime.Now
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5003/api/values");
            var response = await client.PostAsJsonAsync("", data);
        }
    }
}
