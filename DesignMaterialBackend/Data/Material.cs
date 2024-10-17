namespace DesignMaterialBackend.Data
{
    public class Material
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public int CountDownloaded { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }

        public Guid MaterialTypeId { get; set; }

        public MaterialType MaterialTypes { get; set; }
        
    }
}
