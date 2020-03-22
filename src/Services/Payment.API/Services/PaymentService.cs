using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Payment.API.Models;
using Payment.API.Repositories;

namespace Payment.API.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _repository;

        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ProcessPaymentAsync(PaymentDetailsDto paymentDetails)
        {
            // Save payment details
            var newPaymentDetails = CreateNewPayment(paymentDetails);
            _repository.AddPayment(newPaymentDetails);

            // Send request to bank
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var postBody = new StringContent(JsonConvert.SerializeObject(paymentDetails), System.Text.Encoding.UTF8, "application/json");
            var postResponse = await client.PostAsync("https://localhost:44399/api/MockBank/", postBody);

            // Update details with response


            // Return payment ID
            return newPaymentDetails.PaymentId;
        }

        public void GetPaymentById(int paymentId)
        {
            throw new NotImplementedException();
        }

        private Models.Database.Payment CreateNewPayment(PaymentDetailsDto paymentDetails)
        {
            return new Models.Database.Payment
            {
                Amount = paymentDetails.Amount,
                Currency = paymentDetails.Currency,
                Cvv = paymentDetails.Cvv,
                ExpiryDate = paymentDetails.ExpiryDate,
                MaskedCardNumber = paymentDetails.CardNumber.Substring(paymentDetails.CardNumber.Length - 4),
                PaymentStatus = PaymentStatusEnum.Pending
            };
        }
    }
}
