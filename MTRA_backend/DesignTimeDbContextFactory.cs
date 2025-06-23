using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MTRA_Backend.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MtraDbContext>
    {
        public MtraDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MtraDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=MTRA;Trusted_Connection=True;");
            // If using SQLite, replace with: optionsBuilder.UseSqlite("Data Source=MTRA.db");

            return new MtraDbContext(optionsBuilder.Options);
        }
    }
}
