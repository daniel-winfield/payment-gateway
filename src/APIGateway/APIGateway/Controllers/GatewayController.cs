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

        // GET api/gateway/validkey/1
        /// <summary>
        /// Returns the payment corresponding to the passed ID
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        [HttpGet("{apiKey}/{paymentId}")]
        public async Task<ActionResult<GetPayment_Response>> GetPaymentDetailsById(string apiKey, int paymentId)
        {
            if (!_service.IsValidApiKey(apiKey))
            {
                return BadRequest("Invalid API key");
            }

            var payment = await _service.GetPaymentById(paymentId);
            return payment;
        }

        // POST api/gateway/validkey
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

            var isValid = await _service.ProcessPayment(paymentDetails);

            return Ok(isValid);
        }
    }
}
