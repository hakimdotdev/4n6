using AutoRecon.Domain.Entities.Azure;
using Microsoft.EntityFrameworkCore;

namespace AutoRecon.Domain.Entities
{
    public interface IAutoReconDbContext
    {
        DbSet<AzureVm> AzureVms { get; set; }
        DbSet<Blob> Blobs { get; set; }
        DbSet<ForensicImage> ForensicImages { get; set; }
        DbSet<Scan> Scans { get; set; }
    }
}