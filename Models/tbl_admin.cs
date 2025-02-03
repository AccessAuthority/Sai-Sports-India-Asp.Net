using System.ComponentModel.DataAnnotations;

namespace SaiSports.Models
{
    public class tbl_admin
    {
        [Key]
        public int id { get; set; }
        public string? userid { get; set; }
        public string? password { get; set; }
    }
}
