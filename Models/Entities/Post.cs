namespace blog.api.Models.Entities
{
    public class Post
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string summary { get; set; }
        public string UrlHandle { get; set; }
        public string FeaturedImageUrl { get; set; }
        public bool Visible { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
