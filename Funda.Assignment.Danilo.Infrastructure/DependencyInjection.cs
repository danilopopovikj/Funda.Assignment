using Funda.Assignment.Danilo.Application.Repositories;
using Funda.Assignment.Danilo.Infrastructure.HttpRepositories.Listings;
using Funda.Assignment.Danilo.Infrastructure.PollyPolicies;
using Microsoft.Extensions.DependencyInjection;

namespace Funda.Assignment.Danilo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient(nameof(HttpListingRepository))
                .AddPolicyHandler(RetryPolicies.GetPolicy());

            return services
                .AddSingleton<IListingRepository, HttpListingRepository>();
        }
  
    }
}
