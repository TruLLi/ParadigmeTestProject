using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Vjezba2.Models;
using Microsoft.Extensions.Hosting;

namespace Vjezba2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var env = host.Services.GetService<IWebHostEnvironment>();
            if (env.IsDevelopment())
            {
                using (var scope = host.Services.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<Context>();
                    var logger = scopedServices.GetRequiredService<ILogger<Startup>>();
                    db.Database.EnsureCreated();
                }
            }
            host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}
