using Funda.Assignment.Danilo.Application.UseCases.Reports.RealEstateAgents.Dtos;

namespace Funda.Assignment.Danilo.Application.UseCases.Reports.Listings
{
    public interface IRealEstateAgentRankingService
    {
        public Task<IEnumerable<RealEstateAgentRankDto>> RankByNumberOfListingsForSaleAsync(int rankListSize);
        public Task<IEnumerable<RealEstateAgentRankDto>> RankByNumberOfListingsForSaleWithGardenAsync(int rankListSize);
    }
}
