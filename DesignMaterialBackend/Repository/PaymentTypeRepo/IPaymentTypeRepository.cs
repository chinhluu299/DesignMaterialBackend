using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.PaymentTypeRepo
{
    public interface IPaymentTypeRepository
    {
        IEnumerable<PaymentType> GetAll();
        PaymentType GetById(int id);
        void Insert(PaymentType paymentType);
        void Update(PaymentType paymentType);
        void Delete(int id);
        void Save();
    }
}
