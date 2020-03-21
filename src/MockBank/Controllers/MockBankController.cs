using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MockBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockBankController : ControllerBase
    {
        // POST api/MockBank
        [HttpPost]
        public bool Post([FromBody] string cardNumber, [FromBody]string expiryDate, [FromBody]double amount, [FromBody]string currency, [FromBody]string cvv)
        {
            if (cardNumber == "1111222233334444")
            {
                return true;
            }

            return false;
        }
    }
}
