using System.ComponentModel.DataAnnotations;

namespace SaiSports.Models
{
    public class tbl_products
    {
        [Key]
        public int id { get; set; }
        public string? pname { get; set; }
        public string? pcategory { get; set; }
        public string? img1 { get; set; }
        public string? img2 { get; set; }
        public string? img3 { get; set; }
        public string? img4 { get; set; }
        public string? img5 { get; set; }
        public string? fabric { get; set; }
        public string? fabric_weight { get; set; }
        public string? weave_type { get; set; }
        public string? color_pattern { get; set; }
        public string? size { get; set; }
        public string? fit_type { get; set; }
        public string? thread_count { get; set; }
        public string? author { get; set; }
        public string? date { get; set; }
        public string? pcontent { get; set; }
        public string? pdesc { get; set; }
        public string? stretchability { get; set; }
        public string? wash_care{ get; set; }
        public string? closure_type { get; set; }
        public string? special_features { get; set; }
        public string? season_suitability { get; set; }
        public string? style { get; set; }
    }
}
