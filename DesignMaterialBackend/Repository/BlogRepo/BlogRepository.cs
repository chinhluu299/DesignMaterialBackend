using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.BlogRepo
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DesignMaterialDbContext _context;

        public BlogRepository(DesignMaterialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Blog> GetAll()
        {
            return _context.Blogs.ToList();
        }

        public Blog GetById(int id)
        {
            return _context.Blogs.Find(id);
        }

        public void Insert(Blog blog)
        {
            _context.Blogs.Add(blog);
            Save();
        }

        public void Update(Blog blog)
        {
            _context.Blogs.Update(blog);
            Save();
        }

        public void Delete(int id)
        {
            var blog = _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
