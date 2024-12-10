using Microsoft.EntityFrameworkCore;

namespace SaiSports.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<tbl_blog> tbl_blog { get; set; }
        public DbSet<tbl_products> tbl_products { get; set; }
        public DbSet<tbl_enquiries> tbl_enquiries { get; set; }

    }
}
