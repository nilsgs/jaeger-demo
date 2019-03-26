using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanetCatalogue.Models;
using PlanetCatalogue.Services;
using Shared;

namespace PlanetCatalogue
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<PlanetContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("Planets")));

            services.AddHttpClient<SwapiService>(c =>
            {
                c.BaseAddress = new Uri("https://swapi.co");
            });

            services.AddJaeger();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
