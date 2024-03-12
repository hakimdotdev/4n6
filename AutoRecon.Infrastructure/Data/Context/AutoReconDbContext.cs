using AutoRecon.Domain.Entities;
using AutoRecon.Domain.Entities.Azure;
using AutoRecon.Domain.Entities.Fido2;
using AutoRecon.Domain.Entities.Recon;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoRecon.Infrastructure
{
    public class AutoReconDbContext(DbContextOptions<AutoReconDbContext> options) : IdentityDbContext<User>(options), IAutoReconDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Scan> Scans { get; set; }
        public DbSet<AzureVm> AzureVms { get; set; }
        public DbSet<Blob> Blobs { get; set; }
        public DbSet<ForensicImage> ForensicImages { get; set; }
        public DbSet<FidoStoredCredential> FidoStoredCredential { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("your_connection_string_here");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}