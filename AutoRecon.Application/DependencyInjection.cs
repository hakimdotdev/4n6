using AutoRecon.Application.Interfaces;
using AutoRecon.Application.Services;
using AutoRecon.Application.Services.Vm;
using Microsoft.Extensions.DependencyInjection;

namespace AutoRecon.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSignalR();
        services.AddScoped<AzureVmService>();
        services.AddScoped<AwsVmService>();
        services.AddScoped<VmWareVmService>();
        services.AddScoped<ICommandFactory, CommandFactory>();
        services.AddScoped<IFileUploadService, FileUploadService>();
        services.AddMediator();
        // services.AddMediator(o => o.ServiceLifetime = ServiceLifetime.Scoped);

        return services;
    }
}