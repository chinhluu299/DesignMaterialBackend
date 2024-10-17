namespace DesignMaterialBackend.Data
{
    public class MaterialType 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Other { get; set; }

        public List<Material> Materials { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }

    }
}
