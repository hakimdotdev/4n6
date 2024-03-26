using AutoRecon.Domain.Entities;
using AutoRecon.Domain.Entities.Azure;
using AutoRecon.Domain.Entities.Fido2;
using AutoRecon.Domain.Entities.Forensics;
using Microsoft.EntityFrameworkCore;

namespace AutoRecon.Infrastructure.Data.Context;

public interface IAutoReconDbContext
{
    DbSet<User> Users { get; set; }

    DbSet<AzureVm> AzureVms { get; set; }
    DbSet<Blob> Blobs { get; set; }
    DbSet<ForensicImage> ForensicImages { get; set; }
    DbSet<FidoStoredCredential> FidoStoredCredential { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}