using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public class GatewayService : IGatewayService
    {
        private static readonly HttpClient client = new HttpClient();

        public GatewayService()
        {
        }

        public bool IsValidApiKey(string apiKey)
        {
            var isValidKeyTask = ProcessStuff("https://localhost:44330/api/Auth/" + apiKey);

            isValidKeyTask.Wait();
            var isValidKey = Boolean.Parse(isValidKeyTask.Result);
            return isValidKey;
        }

        public async Task<bool> ProcessPayment(string cardNumber, string expiryDate, double amount, string currency, string cvv)
        {
            var isCardValid = await IsCardValid(cardNumber);
            return isCardValid;
        }

        private async Task<bool> IsCardValid(string cardNumber)
        {
            var isCardValidStr = await ProcessStuff("https://localhost:44389/api/Validation/CardNumber/" + cardNumber);
            return Boolean.Parse(isCardValidStr);
        }

        private async Task<string> ProcessStuff(string url)
        {
            //var x = await ValidateCard();

            client.DefaultRequestHeaders.Accept.Clear();
            ////client.DefaultRequestHeaders.Accept.Add(
            ////    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            ////client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync(url);

            var result = await stringTask;
            return result;
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
