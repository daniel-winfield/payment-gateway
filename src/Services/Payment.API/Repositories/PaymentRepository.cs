using Payment.API.DataAccess;
using System.Linq;

namespace Payment.API.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentContext _context;

        public PaymentRepository(PaymentContext context)
        {
            _context = context;
        }

        public void AddPayment(Models.Database.Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public Models.Database.Payment GetPaymentById(int paymentId)
        {
            return _context.Payments.SingleOrDefault(p => p.PaymentId == paymentId);
        }
    }
}
