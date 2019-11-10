using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Account.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ConfigSettings configSetting { get; set; }

        public ValuesController(IOptions<ConfigSettings> settings)
        {
            this.configSetting = settings.Value;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var result = LogTask("Information", "Get Account");
                return new string[] { "Account - value1", "value2" };
            } catch (Exception ex)
            {
                var log = LogTask("Error", ex.Message);
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
        public void Post([FromBody] UserAccount value)
        {
            try
            {
                var log = LogTask("Information", "New Account created for: "+ value.userID);
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserAccount value)
        {
            try
            {
                var log = LogTask("Information", "Update Account created for: " + value.userID);
            }
            catch (Exception ex)
            {
                var log = LogTask("Error", ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int userID)
        {
            try
            {
                var log = LogTask("Information", "Account deleted for: " + userID);
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
                apiName = "Account",
                exception = value,
                type = typ,
                time = DateTime.Now
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri(this.configSetting.LoggerAPI);
            var response = await client.PostAsJsonAsync("", data);
        }
    }
}
