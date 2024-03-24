using Microsoft.Extensions.DependencyInjection;

namespace AutoRecon.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSignalR();



            services.AddMediator();
            return services;
        }
    }
}