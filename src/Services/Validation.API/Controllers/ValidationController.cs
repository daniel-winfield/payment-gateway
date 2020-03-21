using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Validation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        // GET api/Validation/CardNumber/{cardNumber:string}
        [HttpGet("CardNumber/{cardNumber}")]
        public ActionResult<bool> IsCardNumberValid(string cardNumber)
        {
            // These rules could be expanded to match the rules for different card providers. This solution was used for brevity.
            if (cardNumber.Length != 16)
            {
                return false;
            }

            var rx = new Regex("([0-9]{16}$)");
            
            return rx.IsMatch(cardNumber);
        }
    }
}
