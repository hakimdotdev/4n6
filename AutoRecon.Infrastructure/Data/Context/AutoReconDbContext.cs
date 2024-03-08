using AutoRecon.Domain.Entities.Azure;
using AutoRecon.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AutoRecon.Domain.Entities
{
    public class AutoReconDbContext : DbContext, IAutoReconDbContext
    {
        public DbSet<Scan> Scans { get; set; }
        public DbSet<AzureVm> AzureVms { get; set; }
        public DbSet<Blob> Blobs { get; set; }
        public DbSet<ForensicImage> ForensicImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("your_connection_string_here");
        }
    }
}
