namespace APIGateway.Models
{
    public enum LogTypeEnum
    {
        // Many more log types could be added 
        Error,
        AuthSuccess,
        AuthFailure,
        ValidationSuccess,
        ValidationFailure,
        PaymentSuccess,
        PaymentFailure
    }
}
