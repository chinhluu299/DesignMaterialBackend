namespace DesignMaterialBackend.Data
{
    public class Material
    {
        public string Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public int CountDownloaded { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; }
        public List<MaterialType> MaterialTypes { get; set; }
        
    }
}
