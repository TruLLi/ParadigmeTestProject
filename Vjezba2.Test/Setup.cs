using Lambda3.AspNetCore.Mvc.Testing;
//using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Testing;

namespace Vjezba2.Test
{
    [SetUpFixture]
    public class Setup
    {
        private WebApplicationFactory<Startup> webAppFactory;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            StartApiServer();
            BaseIntegration.WebAppFactory = webAppFactory;
            await webAppFactory.MigrateDbAndSeedAsync();
        }

        private void StartApiServer() => webAppFactory = new WebApplicationFactory<Startup>(inMemory: true).EnsureServerStarted();

        [OneTimeTearDown]
        public void OneTimeTearDown() => webAppFactory?.Dispose();
    }
}
