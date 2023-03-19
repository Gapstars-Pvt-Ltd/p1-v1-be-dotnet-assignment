using System;
using System.Reflection;
using Domain.Aggregates.AirportAggregate;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Repositores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Domain.Aggregates.FlightAggregate;
using System.Linq;
using API.Installers;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // get all Installer Instance that implment IInstall Interface
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(x=> typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance)
                .Cast<IInstaller>().ToList();

            // register All Installers
            installers.ForEach(x => x.InstallService(services, Configuration));


            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}