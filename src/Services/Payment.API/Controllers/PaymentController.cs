using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Models;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        // GET api/Payment/5
        [HttpGet("{id}")]
        public ActionResult<string> GetPaymentById(int id)
        {
            return "value";
        }

        // POST api/Payment
        [HttpPost]
        public void ProcessPayment([FromBody] PaymentDetailsDto paymentDetails)
        {
        }
    }
}
