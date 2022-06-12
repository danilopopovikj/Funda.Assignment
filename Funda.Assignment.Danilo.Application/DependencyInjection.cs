using Funda.Assignment.Danilo.Application.UseCases.Reports.Listings;
using Microsoft.Extensions.DependencyInjection;

namespace Funda.Assignment.Danilo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddSingleton<IRealEstateAgentRankingService, RealEstateAgentRankingService>();
        }
    }
}
