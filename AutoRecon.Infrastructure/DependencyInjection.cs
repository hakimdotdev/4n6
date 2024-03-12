using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace AutoRecon.Infrastructure
{
    public static class InfrastructureStartup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            //var jss = new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore,
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    TypeNameHandling = TypeNameHandling.Auto
            //};

            //const string redisConfigurationKey = "redis";
            //services.AddSingleton(typeof(ICacheManagerConfiguration),
            //    new CacheManager.Core.ConfigurationBuilder()
            //        .WithJsonSerializer(serializationSettings: jss, deserializationSettings: jss)
            //        .WithUpdateMode(CacheUpdateMode.Up)
            //        .WithRedisConfiguration(redisConfigurationKey, config =>
            //        {
            //            config.WithAllowAdmin()
            //                .WithDatabase(0)
            //                .WithEndpoint("localhost", 6379)
            //                // Enables keyspace notifications to react on eviction/expiration of items.
            //                // Make sure that all servers are configured correctly and 'notify-keyspace-events' is at least set to 'Exe', otherwise CacheManager will not retrieve any events.
            //                // You can try 'Egx' or 'eA' value for the `notify-keyspace-events` too.
            //                // See https://redis.io/topics/notifications#configuration for configuration details.
            //                .EnableKeyspaceEvents();
            //        })
            //        .WithMaxRetries(100)
            //        .WithRetryTimeout(50)
            //        .WithRedisCacheHandle(redisConfigurationKey)
            //        .Build());
            //services.AddSingleton(typeof(ICacheManager<>), typeof(BaseCacheManager<>));

            services.AddMemoryCache();

            var sp = services.BuildServiceProvider();

            var cacheSvc = sp.GetService<IMemoryCache>();

            var connstring = Environment.GetEnvironmentVariable("CONNECTIONSTRING");

            return services.AddDbContext<AutoReconDbContext>((provider, options) =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                //options.UseMySql(connstring, ServerVersion.AutoDetect(connstring), opt =>
                //{
                //    opt.CommandTimeout((int)TimeSpan.FromSeconds(60).TotalSeconds);
                //    opt.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                //});
                //options.UseMemoryCache(cacheSvc);
            });
        }
    }
}