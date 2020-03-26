using APIGateway.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public class GatewayService : IGatewayService
    {
        public bool IsValidApiKey(string apiKey)
        {
            var isValidKeyTask = GetStringAsync("https://localhost:44330/api/Auth/" + apiKey);

            isValidKeyTask.Wait();
            var isValidKey = Boolean.Parse(isValidKeyTask.Result);

            if (isValidKey)
            {
                LogEvent(new LogDto { LogType = LogTypeEnum.AuthSuccess, Message = String.Format("API key ({0}) authentication successful", apiKey) });
            }
            else
            {
                LogEvent(new LogDto { LogType = LogTypeEnum.AuthFailure, Message = String.Format("API key ({0}) authentication failed", apiKey) });
            }

            return isValidKey;
        }

        public async Task<int> ProcessPayment(PaymentDetailsDto paymentDetails)
        {
            var isCardValid = await IsValidCard(paymentDetails.CardNumber);

            if (!isCardValid)
            {
                LogEvent(new LogDto { LogType = LogTypeEnum.ValidationFailure, Message = "Invalid card number" });
                throw new ArgumentException("Card number is invalid");
            }

            LogEvent(new LogDto { LogType = LogTypeEnum.ValidationSuccess, Message = "Valid card number" });

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var postBody = new StringContent(JsonConvert.SerializeObject(paymentDetails), System.Text.Encoding.UTF8, "application/json");
                var postResponse = await client.PostAsync("https://localhost:44399/api/Payment/", postBody);

                var responseStr = await postResponse.Content.ReadAsStringAsync();
                return int.Parse(responseStr);
            }
        }

        public async Task<GetPayment_Response> GetPaymentById(int paymentId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var postResponse = await client.GetAsync(String.Format("https://localhost:44399/api/Payment/{0}", paymentId));

                return await postResponse.Content.ReadAsAsync<GetPayment_Response>();
            }
        }

        private async Task<bool> IsValidCard(string cardNumber)
        {
            var isCardValidStr = await GetStringAsync("https://localhost:44389/api/Validation/CardNumber/" + cardNumber);
            return Boolean.Parse(isCardValidStr);
        }

        private async Task<string> GetStringAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var stringTask = client.GetStringAsync(url);

                var result = await stringTask;
                return result;
            }
        }

        private void LogEvent(LogDto log)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var postBody = new StringContent(JsonConvert.SerializeObject(log), System.Text.Encoding.UTF8, "application/json");
                client.PostAsync("https://localhost:44339/api/Log/", postBody);
            }
        }
    }

    public enum ServicePorts
    {
        Validation = 44389,
        Logging = 44339,
        Auth = 44330,
        Payment = 44399
    }
}
