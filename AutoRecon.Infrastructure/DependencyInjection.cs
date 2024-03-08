using AutoRecon.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace AutoRecon.Infrastructure
{
    public static class InfrastructureStartup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services.AddSingleton<IAutoReconDbContext, AutoReconDbContext>();

        }
    }
}
