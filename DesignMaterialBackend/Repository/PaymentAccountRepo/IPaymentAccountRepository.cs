using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.PaymentAccountRepo
{
    public interface IPaymentAccountRepository
    {
        IEnumerable<PaymentAccount> GetAll();
        PaymentAccount GetById(int id);
        void Insert(PaymentAccount paymentType);
        void Update(PaymentAccount paymentType);
        void Delete(int id);
        void Save();
    }
}
