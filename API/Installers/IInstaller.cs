using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Installers
{
    public interface IInstaller
    {
        void InstallService(IServiceCollection services,IConfiguration configuration);


    }
}
