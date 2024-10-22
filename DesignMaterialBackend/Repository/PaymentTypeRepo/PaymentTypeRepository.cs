using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.PaymentTypeRepo
{
    public class PaymentTypeRepository : IPaymentTypeRepository
    {
        private readonly DesignMaterialDbContext _context;

        public PaymentTypeRepository(DesignMaterialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PaymentType> GetAll()
        {
            return _context.PaymentTypes.ToList();
        }

        public PaymentType GetById(int id)
        {
            return _context.PaymentTypes.Find(id);
        }

        public void Insert(PaymentType pt)
        {
            _context.PaymentTypes.Add(pt);
            Save();
        }

        public void Update(PaymentType pt)
        {
            _context.PaymentTypes.Update(pt);
            Save();
        }

        public void Delete(int id)
        {
            var pt = _context.PaymentTypes.Find(id);
            _context.PaymentTypes.Remove(pt);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();

        }
    }
}
