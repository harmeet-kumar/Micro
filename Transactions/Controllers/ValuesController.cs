using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transactions.Model;

namespace Transactions.Controllers
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
                var result = LogTask("Information", "Get Transaction Called");
                return new string[] { "Transactions value1", "value2" };
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", "Transaction error: " + ex.Message);
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
        public void Post([FromBody] Transaction value)
        {
            try
            {
                var log = LogTask("Information", "Transaction Completed for: " + value.userID);
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Transaction value)
        {
            try
            {
                var log = LogTask("Information", "Transaction Updated for: " + value.userID);
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
                var log = LogTask("Information", "Transaction deleted for: " + id);
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", ex.Message);
            }
        }

        private async Task LogTask(string typeOfLog, string value)
        {
            var data = new
            {
                apiName = "Transactions",
                exception = value,
                type = typeOfLog,
                time = DateTime.Now
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5003/api/values");
            var response = await client.PostAsJsonAsync("", data);
        }
    }
}
