using Funda.Assignment.Danilo.Application;
using Funda.Assignment.Danilo.Infrastructure;
using Funda.Assignment.Danilo.Infrastructure.HttpRepositories.Listings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Funda.Assignment.Danilo.Console
{
    public static class DependencyInjection
    {
        public static IServiceProvider BuildServiceProvider()
        {
            var config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false)
                        .Build();

            var listingApiConfig = new ListingApiConfig();
            config.GetSection(nameof(ListingApiConfig)).Bind(listingApiConfig);

            return new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .AddApplication()
                .AddInfrastructure()
                .AddSingleton(listingApiConfig)
                .BuildServiceProvider();
        }
    }
}
