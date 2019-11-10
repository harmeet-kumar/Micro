using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logger.Model;
using Microsoft.AspNetCore.Mvc;

namespace Logger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        
        public ValuesController()
        {
            //LogList.logs.Add(
            //    new Log()
            //    {
            //        apiName = "account",
            //        exception = "Expection 1",
            //        time = DateTime.Now,
            //        type = "information"
            //    });
            //LogList.logs.Add(
            //    new Log()
            //    {
            //        apiName = "account",
            //        exception = "Expection 1",
            //        time = DateTime.Now,
            //        type = "error"
            //    });
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Log>> Get()
        {
            return LogList.logs;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Log>> Get(string id)
        {
            List<Log> selectedLogs = new List<Log>();
            foreach(var log in LogList.logs)
            {
                if(log.apiName.Equals(id))
                {
                    selectedLogs.Add(log);
                }
            }
            return selectedLogs;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Log value)
        {
            LogList.logs.Add(value);
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
