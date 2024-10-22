using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.CurrencyUnitRepo
{
    public interface ICurrencyUnitRepository
    {
        IEnumerable<CurrencyUnit> GetAll();
        CurrencyUnit GetById(int id);
        void Insert(CurrencyUnit currencyUnit);
        void Update(CurrencyUnit currencyUnit);
        void Delete(int id);
        void Save();
    }
}
