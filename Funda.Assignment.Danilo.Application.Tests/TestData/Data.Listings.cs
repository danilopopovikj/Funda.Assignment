using Bogus;
using Funda.Assignment.Danilo.Domain;
using System;
using System.Collections.Generic;

namespace Funda.Assignment.Danilo.Application.Tests.TestData
{
    public static partial class Data
    {
        public static List<Listing> GetListings(int numberOfListings, int numberOfAgents) => new Faker<Listing>("en")
            .RuleFor(x => x.MakelaarId, x => new Random().Next(numberOfAgents))
            .RuleFor(x => x.MakelaarNaam, x => x.Name.Random.String(1,5))
            .Generate(numberOfListings);
    }
}
