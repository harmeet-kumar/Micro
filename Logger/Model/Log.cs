using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Model
{
    public class Log
    {
        public string apiName;
        public DateTime time = DateTime.Now;
        public string exception;
        public string type;
    }

    public static class LogList
    {
        public static List<Log> logs = new List<Log>();
    }
}
