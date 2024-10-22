using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.ReceiptRepo
{
    public interface IReceiptRepository
    {
        IEnumerable<Receipt> GetAll();
        Receipt GetById(int id);
        void Insert(Receipt material);
        void Update(Receipt material);
        void Delete(int id);
        void Save();
    }
}
