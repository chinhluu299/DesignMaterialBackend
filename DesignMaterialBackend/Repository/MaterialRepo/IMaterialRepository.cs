using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.MaterialRepo
{
    public interface IMaterialRepository
    {
        IEnumerable<Material> GetAll();
        Material GetById(int id);
        void Insert(Material material);
        void Update(Material material);
        void Delete(int id);
        void Save();
    }
}
