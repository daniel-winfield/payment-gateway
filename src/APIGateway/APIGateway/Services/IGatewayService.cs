using APIGateway.Models;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public interface IGatewayService
    {
        Task<GetPayment_Response> GetPaymentById(int paymentId);

        bool IsValidApiKey(string apiKey);

        Task<bool> ProcessPayment(PaymentDetailsDto paymentDetails);
    }
}
