using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.MaterialTypeRepo
{
    public interface IMaterialTypeRepository
    {
        IEnumerable<MaterialType> GetAll();
        MaterialType GetById(int id);
        void Insert(MaterialType material);
        void Update(MaterialType material);
        void Delete(int id);
        void Save();
    }
}
