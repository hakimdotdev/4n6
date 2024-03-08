using Microsoft.EntityFrameworkCore;

namespace AutoRecon.Domain.Entities
{
    public class AutoReconDbContext : DbContext
    {
        public DbSet<Scan> Scans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("your_connection_string_here");
        }
    }
}
