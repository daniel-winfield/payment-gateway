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
            var postResponse = await client.PostAsync("https://localhost:44378/api/MockBank/", postBody);

            // Update details with response
            UpdatePaymentStatus(newPaymentDetails.PaymentId, postResponse.IsSuccessStatusCode);

            // Return payment ID
            return newPaymentDetails.PaymentId;
        }

        public GetPayment_Response GetPaymentById(int paymentId)
        {
            var payment = _repository.GetPaymentById(paymentId);
            return ToPaymentResponse(payment);
        }

        private void UpdatePaymentStatus(int paymentId, bool isSuccess)
        {
            var payment = _repository.GetPaymentById(paymentId);
            payment.PaymentStatus = isSuccess ? PaymentStatusEnum.Completed : PaymentStatusEnum.Failed;
            _repository.SaveChanges();
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

        private GetPayment_Response ToPaymentResponse(Models.Database.Payment paymentDetails)
        {
            return new GetPayment_Response
            {
                Amount = paymentDetails.Amount,
                MaskedCardNumber = String.Format("**** **** **** {0}", paymentDetails.MaskedCardNumber),
                Currency = paymentDetails.Currency,
                Cvv = paymentDetails.Cvv,
                ExpiryDate = paymentDetails.ExpiryDate,
                PaymentStatus = paymentDetails.PaymentStatus
            };
        }
    }
}
