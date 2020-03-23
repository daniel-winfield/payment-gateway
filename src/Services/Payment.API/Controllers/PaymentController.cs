using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Models;
using Payment.API.Services;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        // GET api/Payment/5
        [HttpGet("{id}")]
        public ActionResult<string> GetPaymentById(int id)
        {
            try
            {
                var payment = _service.GetPaymentById(id);
                return Ok(payment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/Payment
        [HttpPost]
        public async Task<ActionResult<int>> ProcessPayment([FromBody] PaymentDetailsDto paymentDetails)
        {
            try
            {
                var newPaymentId = await _service.ProcessPaymentAsync(paymentDetails);
                return Ok(newPaymentId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
