namespace blog.api.Models.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string summary { get; set; } = string.Empty;
        public string FeaturedImageUrl { get; set; } = string.Empty;
        public bool Visible { get; set; }
        public string Author { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }


    }
}
