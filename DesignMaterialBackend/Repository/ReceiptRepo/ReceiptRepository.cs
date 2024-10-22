using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.ReceiptRepo
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly DesignMaterialDbContext _context;

        public ReceiptRepository(DesignMaterialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Receipt> GetAll()
        {
            return _context.Receipts.ToList();
        }

        public Receipt GetById(int id)
        {
            return _context.Receipts.Find(id);
        }

        public void Insert(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            Save();
        }

        public void Update(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            Save();
        }

        public void Delete(int id)
        {
            var currencyUnit = _context.CurrencyUnits.Find(id);
            _context.CurrencyUnits.Remove(currencyUnit);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
