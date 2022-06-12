using Funda.Assignment.Danilo.Application.Repositories;
using Funda.Assignment.Danilo.Application.UseCases.Reports.RealEstateAgents.Dtos;
using Funda.Assignment.Danilo.Domain;

namespace Funda.Assignment.Danilo.Application.UseCases.Reports.Listings
{
    public class RealEstateAgentRankingService : IRealEstateAgentRankingService
    {
        private readonly IListingRepository _listingsRepository;
        public RealEstateAgentRankingService(IListingRepository listingRepository)
        {
            _listingsRepository = listingRepository;
        }
        public async Task<IEnumerable<RealEstateAgentRankDto>> RankByNumberOfListingsForSaleAsync(int rankListMaxSize = 10)
        {
            var listingsForSale = await _listingsRepository.GetListingsForSaleAsync();

            var listings = RankAgentsByNumberOfListings(listingsForSale, rankListMaxSize);

            return listings;
        }

        public async Task<IEnumerable<RealEstateAgentRankDto>> RankByNumberOfListingsForSaleWithGardenAsync(int rankListMaxSize = 10)
        {
            var listingsWithGardenForSaleWithGarden = await _listingsRepository.GetListingsForSaleWithGardenAsync();

            var rankedRealEstateAgents = RankAgentsByNumberOfListings(listingsWithGardenForSaleWithGarden, rankListMaxSize);

            return rankedRealEstateAgents;
        }

        private IEnumerable<RealEstateAgentRankDto> RankAgentsByNumberOfListings(IEnumerable<Listing> listings, int rankListMaxSize = 10)
        {
            var rankedRealEstateAgents = listings.GroupBy(x => x.MakelaarId)
                           .OrderByDescending(x => x.Count())
                           .Take(rankListMaxSize)
                           .Select(x => new RealEstateAgentRankDto() { Id = x.Key, Name = x.First().MakelaarNaam, NumberOfListings = x.Count() });

            return rankedRealEstateAgents;
        }
    }
}
