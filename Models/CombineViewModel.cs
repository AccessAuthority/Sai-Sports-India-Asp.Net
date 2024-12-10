using Microsoft.EntityFrameworkCore;

namespace SaiSports.Models
{
    public class CombineViewModel
    {

        public tbl_blog CurrentBlog { get; set; }
        public List<tbl_blog> RelatedBlogs { get; set; }
    }
}
