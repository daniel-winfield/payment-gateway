namespace APIGateway.Models
{
    public class GetPayment_Response
    {
        public string MaskedCardNumber { get; set; }

        public string ExpiryDate { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Cvv { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }
    }
}
