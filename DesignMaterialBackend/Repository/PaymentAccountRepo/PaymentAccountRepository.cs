using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.PaymentAccountRepo
{
    public class PaymentAccountRepository : IPaymentAccountRepository
    {
        private readonly DesignMaterialDbContext _context;

        public PaymentAccountRepository(DesignMaterialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PaymentAccount> GetAll()
        {
            return _context.PaymentAccounts.ToList();
        }

        public PaymentAccount GetById(int id)
        {
            return _context.PaymentAccounts.Find(id);
        }

        public void Insert(PaymentAccount pt)
        {
            _context.PaymentAccounts.Add(pt);
            Save();
        }

        public void Update(PaymentAccount pt)
        {
            _context.PaymentAccounts.Update(pt);
            Save();
        }

        public void Delete(int id)
        {
            var pt = _context.PaymentAccounts.Find(id);
            _context.PaymentAccounts.Remove(pt);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();

        }
    }
}
