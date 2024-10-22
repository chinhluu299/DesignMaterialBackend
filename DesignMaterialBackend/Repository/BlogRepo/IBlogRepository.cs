using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.BlogRepo
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();
        Blog GetById(int id);
        void Insert(Blog blog);
        void Update(Blog blog);
        void Delete(int id);
        void Save();
    }
}
