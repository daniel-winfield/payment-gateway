using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.API.Models.Database
{
    public class Log
    {
        public int LogId { get; set; }

        public string Message { get; set; }

        public int LogType { get; set; }
    }
}
