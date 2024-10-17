namespace DesignMaterialBackend.Data
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int Status { get; set; }
        public int ViewCount { get; set; }
        public string ThumbnailUrl { get; set; }
        public int CategoryID { get; set; }
        public BlogCategory BlogCategory { get; set; }

    }
}
