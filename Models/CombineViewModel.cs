using Microsoft.EntityFrameworkCore;

namespace SaiSports.Models
{
    public class CombineViewModel
    {

        public List<tbl_blog> tbl_blog { get; set; }
        public List<Service> Service { get; set; }
        public List<tbl_products> tbl_products { get; set; }
    }
}
