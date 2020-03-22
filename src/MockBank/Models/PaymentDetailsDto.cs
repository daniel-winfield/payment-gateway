namespace MockBank.Models
{
    public class PaymentDetailsDto
    {
        public string CardNumber { get; set; }

        public string ExpiryDate { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Cvv { get; set; }
    }
}
