using APIGateway.Models;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public interface IGatewayService
    {
        bool IsValidApiKey(string apiKey);

        Task<bool> ProcessPayment(PaymentDetailsDto paymentDetails);
    }
}
