namespace Payment.API.Repositories
{
    public interface IPaymentRepository
    {
        void AddPayment(Models.Database.Payment payment);

        Models.Database.Payment GetPaymentById(int paymentId);
    }
}
