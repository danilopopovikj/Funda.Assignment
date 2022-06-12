using Funda.Assignment.Danilo.Application.Tests.TestData;
using System.Collections;
using System.Collections.Generic;

namespace Funda.Assignment.Danilo.Application.Tests.UseCases.Reports.RealEstateAgents
{
    public class RealEstateAgentRankingServiceTestsFixture : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new()
        {
            new object[] { Data.GetListings(1000, 15), 10, 10 }, // More # of agents than rank list size
            new object[] { Data.GetListings(1000, 5), 10, 5 },  // Less # of agents than rank list size
            new object[] { Data.GetListings(5, 1), 1, 1 }      // Same # of agents than rank list size
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
