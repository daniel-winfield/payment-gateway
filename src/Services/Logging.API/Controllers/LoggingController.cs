using System.Collections.Generic;
using Logging.API.Models;
using Logging.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logging.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILoggingService _service;

        public LoggingController(ILoggingService service)
        {
            _service = service;
        }

        // POST api/Logging
        [HttpPost]
        public void Post([FromBody] LogDto log)
        {
            _service.AddLog(log);
        }
    }
}
