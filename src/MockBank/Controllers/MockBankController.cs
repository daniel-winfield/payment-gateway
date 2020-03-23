using Microsoft.AspNetCore.Mvc;
using MockBank.Models;

namespace MockBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockBankController : ControllerBase
    {
        // POST api/MockBank
        [HttpPost]
        public bool Post([FromBody] PaymentDetailsDto paymentDetails)
        {
            // Example invalid card number - 0000 0000 0000 0000
            if (paymentDetails.CardNumber == "0000000000000000")
            {
                return false;
            }

            return true;
        }
    }
}
