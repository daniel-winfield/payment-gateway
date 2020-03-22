using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public interface IGatewayService
    {
        bool IsValidApiKey(string apiKey);

        Task<bool> ProcessPayment(string cardNumber, string expiryDate, double amount, string currency, string cvv);
    }
}
