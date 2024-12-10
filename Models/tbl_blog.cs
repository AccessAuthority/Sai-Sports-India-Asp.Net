using System.ComponentModel.DataAnnotations;

namespace SaiSports.Models
{
    public class tbl_blog
    {
        [Key]
        public int id { get; set; }
        public string? title { get; set; }
        public string? category  { get; set; }
        public string? tags { get; set; }
        public string? img { get; set; }
        public string? author { get; set; }
        public string? date { get; set; }
        public string? blog_content { get; set; }
        public string? description { get; set; }
    }
}
