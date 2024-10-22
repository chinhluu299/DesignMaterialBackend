using DesignMaterialBackend.Data;

namespace DesignMaterialBackend.Repository.MaterialTypeRepo
{
    public class MaterialTypeRepository : IMaterialTypeRepository
    {
        private readonly DesignMaterialDbContext _context;

        public MaterialTypeRepository(DesignMaterialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MaterialType> GetAll()
        {
            return _context.MaterialTypes.ToList();
        }

        public MaterialType GetById(int id)
        {
            return _context.MaterialTypes.Find(id);
        }

        public void Insert(MaterialType material)
        {
            _context.MaterialTypes.Add(material);
            Save();
        }

        public void Update(MaterialType material)
        {
            _context.MaterialTypes.Update(material);
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
