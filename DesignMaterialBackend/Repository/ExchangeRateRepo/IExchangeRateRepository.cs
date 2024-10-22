using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.ExchangeRateRepo
{
    public interface IExchangeRateRepository
    {
        IEnumerable<ExchangeRate> GetAll();
        ExchangeRate GetById(int id);
        void Insert(ExchangeRate exchangeRate);
        void Update(ExchangeRate exchangeRate);
        void Delete(int id);
        void Save();
    }
}
