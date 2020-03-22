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
            if (paymentDetails.CardNumber == "1111222233334444")
            {
                return true;
            }

            return false;
        }
    }
}
