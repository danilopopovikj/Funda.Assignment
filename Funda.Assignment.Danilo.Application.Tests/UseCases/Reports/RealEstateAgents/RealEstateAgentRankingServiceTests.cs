using FluentAssertions;
using Funda.Assignment.Danilo.Application.Repositories;
using Funda.Assignment.Danilo.Application.UseCases.Reports.Listings;
using Funda.Assignment.Danilo.Domain;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Funda.Assignment.Danilo.Application.Tests.UseCases.Reports.RealEstateAgents
{
    public class RealEstateAgentRankingServiceTests
    {
        [Theory]
        [ClassData(typeof(RealEstateAgentRankingServiceTestsFixture))]
        public async Task Agents_Should_Be_Ranked_By_Number_Of_Listings_For_Sale_Descending(List<Listing> listings, int requestedRankListSize, int expectedResultListSize)
        {
            // Arrange
            var repositoryMock = new Mock<IListingRepository>();
            repositoryMock.Setup(x => x.GetListingsForSaleAsync()).ReturnsAsync(listings);
            var service = new RealEstateAgentRankingService(repositoryMock.Object);

            // Act
            var resultEnumerable = await service.RankByNumberOfListingsForSaleAsync(requestedRankListSize);
            var result = resultEnumerable.ToList();

            // Assert
            result.Count.Should().Be(expectedResultListSize);
            result.Should().BeInDescendingOrder(x => x.NumberOfListings);
            result.Should().OnlyHaveUniqueItems(x => x.Id);
            var mostListings = result.First().Id;
            listings.GroupBy(x => x.MakelaarId)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .First()
                .Should().Be(mostListings);

        }

        [Theory]
        [ClassData(typeof(RealEstateAgentRankingServiceTestsFixture))]
        public async Task Agents_Should_Be_Ranked_By_Number_Of_Listings_For_Sale_With_Garden_Descending(List<Listing> listings, int requestedRankListSize, int expectedResultListSize)
        {
            // Arrange
            var repositoryMock = new Mock<IListingRepository>();
            repositoryMock.Setup(x => x.GetListingsForSaleWithGardenAsync()).ReturnsAsync(listings);
            var service = new RealEstateAgentRankingService(repositoryMock.Object);

            // Act
            var resultEnumerable = await service.RankByNumberOfListingsForSaleWithGardenAsync(requestedRankListSize);
            var result = resultEnumerable.ToList();

            // Assert
            result.Count.Should().Be(expectedResultListSize);
            result.Should().BeInDescendingOrder(x => x.NumberOfListings);
            result.Should().OnlyHaveUniqueItems(x => x.Id);
            var mostListings = result.First().Id;
            listings.GroupBy(x => x.MakelaarId)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .First()
                .Should().Be(mostListings);

        }
    }
}
