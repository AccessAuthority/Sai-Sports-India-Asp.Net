using System.ComponentModel.DataAnnotations;

namespace SaiSports.Models
{
    public class tbl_products
    {
        [Key]
        public int id { get; set; }
        public string? pname { get; set; }
        public string? pcategory { get; set; }
        public string? ptags { get; set; }
        public string? img1 { get; set; }
        public string? img2 { get; set; }
        public string? img3 { get; set; }
        public string? img4 { get; set; }
        public string? img5 { get; set; }
        public string? price { get; set; }
        public string? quantity { get; set; }
        public string? red { get; set; }
        public string? blue { get; set; }
        public string? green { get; set; }
        public string? black { get; set; }
        public string? white { get; set; }
        public string? author { get; set; }
        public string? date { get; set; }
        public string? pcontent { get; set; }
    }
}
