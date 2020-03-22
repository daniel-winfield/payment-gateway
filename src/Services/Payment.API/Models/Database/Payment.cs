using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.Models.Database
{
    public class Payment
    {
        public int PaymentId { get; set; }

        // Would possibly want to store full card number, storing masked version for safety
        public string MaskedCardNumber { get; set; }

        public string ExpiryDate { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Cvv { get; set; }
    }
}