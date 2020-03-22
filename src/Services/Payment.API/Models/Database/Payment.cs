using System.ComponentModel.DataAnnotations;

namespace Payment.API.Models.Database
{
    public class Payment
    {
        public int PaymentId { get; set; }

        // Would possibly want to store full card number, storing masked version for safety
        [MaxLength(4)]
        public string MaskedCardNumber { get; set; }

        public string ExpiryDate { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Cvv { get; set; }

        public PaymentStatusEnum PaymentStatus { get; set; }
    }
}