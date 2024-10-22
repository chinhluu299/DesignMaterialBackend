using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.MaterialRepo
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DesignMaterialDbContext _context;

        public MaterialRepository(DesignMaterialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Material> GetAll()
        {
            return _context.Materials.ToList();
        }

        public Material GetById(int id)
        {
            return _context.Materials.Find(id);
        }

        public void Insert(Material material)
        {
            _context.Materials.Add(material);
            Save();
        }

        public void Update(Material material)
        {
            _context.Materials.Update(material);
            Save();
        }

        public void Delete(int id)
        {
            var material = _context.Materials.Find(id);
            _context.Materials.Remove(material);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
