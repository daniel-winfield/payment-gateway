using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.API.Models
{
    public class LogDto
    {
        public string Message { get; set; }

        public LogType LogType { get; set; }
    }
}
