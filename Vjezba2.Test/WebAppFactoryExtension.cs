using Lambda3.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Vjezba2.Models;

namespace Vjezba2.Test
{
    public static class WebAppFactoryExtension
    {
        public static async Task MigrateDbAndSeedAsync<TStartup>(this WebApplicationFactory<TStartup> webApplicationFactory) where TStartup : class
        {
            var services = webApplicationFactory.Host.Services;

            using (var scope = services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<Context>();
                var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();
                await db.Database.EnsureCreatedAsync();
            }
        }
        public static WebApplicationFactory<TStartup> EnsureServerStarted<TStartup>(this WebApplicationFactory<TStartup> webApplicationFactory) where TStartup : class
        {
            webApplicationFactory.CreateDefaultClient();
            return webApplicationFactory;
        }
    }
}
