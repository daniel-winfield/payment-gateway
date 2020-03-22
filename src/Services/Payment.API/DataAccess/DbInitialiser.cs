using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payment.API.DataAccess
{
    public static class DbInitialiser
    {
        public static void Initialise(PaymentContext context)
        {
            context.Database.EnsureCreated();

            if (context.Payments.Any())
            {
                return;
            }

            var payments = new Models.Database.Payment[]
            {
                new Models.Database.Payment { MaskedCardNumber = "1234", Amount = 12.34, Currency = "GBP", Cvv = "111", ExpiryDate = "01/23" },
                new Models.Database.Payment { MaskedCardNumber = "9999", Amount = 999.9, Currency = "GBP", Cvv = "111", ExpiryDate = "01/23" },
                new Models.Database.Payment { MaskedCardNumber = "5555", Amount = 5555.0, Currency = "USD", Cvv = "111", ExpiryDate = "01/23" }
            };

            foreach (var payment in payments)
            {
                context.Payments.Add(payment);
            }

            context.SaveChanges();
        }
    }
}
