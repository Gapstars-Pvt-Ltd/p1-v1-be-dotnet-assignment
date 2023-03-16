using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddFlightsContext(this IServiceCollection services, string connectionString, string migrationsAssemblyName)
        {
            return services.AddDbContext<FlightsContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptionsAction: npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(migrationsAssemblyName);
                });
            }, ServiceLifetime.Transient);

            // string connectionString, string migrationsAssemblyName

            //services.AddDbContext<FlightsContext>(options =>
            //    options.UseNpgsql(
            //        configuration.ToString(),
            //        b => b.MigrationsAssembly(typeof(FlightsContext).Assembly.FullName)));

            //return services.AddScoped<FlightsContext>(provider => provider.GetService<FlightsContext>());
        }
    }
}