using Microsoft.Extensions.DependencyInjection;

namespace AutoRecon.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //services.AddMediator(cfg =>
            //{
            //    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //    //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            //    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            //});

            //services.AddScoped<IAzureVmService, AzureVmService>();
            services.AddMediator(options =>
            {
                options.Namespace = "AutoRecon.Application";
                options.ServiceLifetime = ServiceLifetime.Scoped;
            });

            return services;
        }
    }
}