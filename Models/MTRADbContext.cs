using Microsoft.EntityFrameworkCore;

namespace MTRADashboard.Models
{
    public class MTRADbContext : DbContext
    {
        public MTRADbContext(DbContextOptions<MTRADbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Accounting> Accountings { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure string PKs as non-Unicode if needed, relationships, etc.
        }
    }
} 