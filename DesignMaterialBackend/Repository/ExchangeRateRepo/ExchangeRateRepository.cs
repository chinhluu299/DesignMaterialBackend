using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.ExchangeRateRepo
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly DesignMaterialDbContext _context;

        public ExchangeRateRepository(DesignMaterialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ExchangeRate> GetAll()
        {
            return _context.ExchangeRates.ToList();
        }

        public ExchangeRate GetById(int id)
        {
            return _context.ExchangeRates.Find(id);
        }

        public void Insert(ExchangeRate exchangeRate)
        {
            _context.ExchangeRates.Add(exchangeRate);
            Save();
        }

        public void Update(ExchangeRate exchangeRate)
        {
            _context.ExchangeRates.Update(exchangeRate);
            Save();
        }

        public void Delete(int id)
        {
            var exchangeRate = _context.ExchangeRates.Find(id);
            _context.ExchangeRates.Remove(exchangeRate);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
