using Infrastructure.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;

namespace API.Installers
{
    public class CorsInstaller : IInstaller
    {
        private const string CorsPolicy = nameof(CorsPolicy);
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            //get cors setting from configuartion 
            var corsSettings = configuration.GetSection(nameof(CorsSettings)).Get<CorsSettings>();
            var origins = new List<string>();
            if (corsSettings.Swagger is not null)
                origins.AddRange(corsSettings.Swagger.Split(';', StringSplitOptions.RemoveEmptyEntries));
         
            // register cosrs policy
            services.AddCors(opt =>
                opt.AddPolicy(CorsPolicy, policy =>
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(origins.ToArray())));
        }
    }
}
