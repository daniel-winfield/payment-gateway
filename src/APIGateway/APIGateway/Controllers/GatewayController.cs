using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _service;

        public GatewayController(IGatewayService service)
        {
            _service = service;
        }

        // GET api/gateway/CD2C1638-1638-72D5-1638-DEADBEEF1638/1
        [HttpGet("{apiKey}/{paymentId}")]
        public ActionResult<string> GetPaymentDetailsById(string apiKey, int paymentId)
        {
            if (!_service.IsValidApiKey(apiKey))
            {
                return BadRequest("Invalid API key");
            }


            ////_service.ProcessStuff("https://localhost:44389/", "api/Validation/CardNumber/1234");

            ////_service.ProcessStuff("https://localhost:44330/", "api/Auth");
            return paymentId.ToString();
        }

        // POST api/gateway/CD2C1638-1638-72D5-1638-DEADBEEF1638
        /// <summary>
        /// Creates a payment
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="paymentDetails"></param>
        /// <returns></returns>
        [HttpPost("{apiKey}")]
        public async Task<ActionResult<bool>> PostPayment(string apiKey, [FromBody] PaymentDetailsDto paymentDetails)
        {
            if (!_service.IsValidApiKey(apiKey))
            {
                return BadRequest("Invalid API key");
            }

            var isValid = await _service.ProcessPayment(paymentDetails.CardNumber, paymentDetails.ExpiryDate, paymentDetails.Amount, paymentDetails.Currency, paymentDetails.Cvv);

            return Ok(isValid);
        }
    }
}
