using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET api/Auth/abc
        [HttpGet("{apiKey}")]
        public ActionResult<bool> Get(string apiKey)
        {
            if (apiKey == "validkey")
            {
                return true;
            }
            return false;
        }
    }
}
