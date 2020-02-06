//using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Net.Http;
using Lambda3.AspNetCore.Mvc.Testing;


namespace Vjezba2.Test
{
    public abstract class BaseIntegration
    {
        private IServiceScope scope;
        protected IServiceProvider serviceProvider;
        protected HttpClient client;

        public static WebApplicationFactory<Startup> WebAppFactory { get; set; }

        [OneTimeSetUp]
        public void BaseIntegrationTestOneTimeSetUp()
        {
            client = WebAppFactory.CreateDefaultClient();
            scope = WebAppFactory.Host.Services.CreateScope();
            serviceProvider = scope.ServiceProvider;
        }

        [OneTimeTearDown]
        public void BaseIntegrationTestOneTimeTearDown() => scope.Dispose();
    }
}
