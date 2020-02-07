using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Vjezba2.Models;
using Microsoft.Extensions.Hosting;
using Metrics;
using System;
using Microsoft.Owin;

//[assembly: OwinStartup(typeof(Vjezba2.Startup))]

namespace Vjezba2
{
    public class Startup
    {
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;


            Metric.Config.WithHttpEndpoint("http://localhost:12345/")
                // .WithAllCounters()
                .WithInternalMetrics()
                .WithReporting(config => config
                    .WithCSVReports(@"c:\temp\reports\", TimeSpan.FromSeconds(30))
                    .WithConsoleReport(TimeSpan.FromSeconds(30))
                    .WithTextFileReport(@"C:\temp\reports\metrics.txt", TimeSpan.FromSeconds(30))
                );

        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddScoped<IDriversRepository, DriversRepository>();

            if (env.IsEnvironment("Test"))
            {
                services.AddEntityFrameworkInMemoryDatabase();
                services.AddDbContext<Context>(options => options.UseInMemoryDatabase("InMemoryDbForTesting"));
            }
            else
            {
                services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DriverDb")));
            }

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
