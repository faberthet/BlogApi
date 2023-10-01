using blog.api.Models.Entities;

namespace blog.api.Models.DTO
{
    public class AddPostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string summary { get; set; }
        public string FeaturedImageUrl { get; set; }
        public bool Visible { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
