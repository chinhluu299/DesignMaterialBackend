using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.CurrencyUnitRepo
{
    public class CurrencyUnitRepository : ICurrencyUnitRepository
    {
        private readonly DesignMaterialDbContext _context;

        public CurrencyUnitRepository(DesignMaterialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CurrencyUnit> GetAll()
        {
            return _context.CurrencyUnits.ToList();
        }

        public CurrencyUnit GetById(int id)
        {
            return _context.CurrencyUnits.Find(id);
        }

        public void Insert(CurrencyUnit currencyUnit)
        {
            _context.CurrencyUnits.Add(currencyUnit);
            Save();
        }

        public void Update(CurrencyUnit currencyUnit)
        {
            _context.CurrencyUnits.Update(currencyUnit);
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
