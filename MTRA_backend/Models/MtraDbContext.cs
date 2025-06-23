using Microsoft.EntityFrameworkCore;

namespace MTRA_Backend.Models
{
    public class MtraDbContext : DbContext
    {
        // Parameterless constructor for design-time support
        public MtraDbContext() { }

        public MtraDbContext(DbContextOptions<MtraDbContext> options) : base(options) { }

        public DbSet<Request> Request { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Agreement> Agreement { get; set; }
        public DbSet<Accounting> Accounting { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
    }
}
