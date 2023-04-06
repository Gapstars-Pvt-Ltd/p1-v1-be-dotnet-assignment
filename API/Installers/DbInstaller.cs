using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace API.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFlightsContext(
               configuration["Database:ConnectionString"],
               typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
        }
    }
}
