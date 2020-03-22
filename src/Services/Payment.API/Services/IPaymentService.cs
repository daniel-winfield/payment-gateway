using Payment.API.Models;
using System.Threading.Tasks;

namespace Payment.API.Services
{
    public interface IPaymentService
    {
        Task<int> ProcessPaymentAsync(PaymentDetailsDto paymentDetails);

        void GetPaymentById(int paymentId);
    }
}
