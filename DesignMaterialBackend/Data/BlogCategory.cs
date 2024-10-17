namespace DesignMaterialBackend.Data
{
    public class BlogCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
